using AuthService.Data;
using AuthService.DTOs;
using AuthService.Interfaces;
using AuthService.Models;
using Google.Apis.Auth;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthService.Services
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _config;

        public AuthServiceImpl(AuthDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string Register(RegisterDTO user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email) ||
                string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Phone))
            {
                throw new Exception("Username, Email, Password and Phone cannot be empty.");
            }

            var newUser = new UserEntity
            {
                UserName = user.Username,
                Email = user.Email,
                Phone = user.Phone,
                Password = PasswordHelper.HashPassword(user.Password),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return "success: user registered";
        }

        public UserEntity? Login(LoginDTO user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            if (existingUser != null && PasswordHelper.VerifyPassword(user.Password!, existingUser.Password!))
                return existingUser;
            return null;
        }

        public UserEntity? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task<UserEntity?> LoginWithGoogle(string idToken)
        {
            var clientId = _config["Google:ClientId"];

            var settings = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new[] { clientId }
            };

            GoogleJsonWebSignature.Payload payload;
            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            }
            catch
            {
                return null;
            }

            var existingUser = _context.Users.FirstOrDefault(u => u.Email == payload.Email);
            if (existingUser != null) return existingUser;

            var newUser = new UserEntity
            {
                UserName = payload.Name ?? payload.Email,
                Email = payload.Email,
                Phone = "",
                Password = PasswordHelper.HashPassword(Guid.NewGuid().ToString()),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
            return _context.Users.FirstOrDefault(u => u.Email == payload.Email);
        }

        public string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
