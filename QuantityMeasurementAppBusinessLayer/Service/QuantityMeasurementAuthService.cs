using Microsoft.AspNetCore.Identity;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Exception;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using BCrypt.Net;
namespace QuantityMeasurementAppBusinessLayer.Service
{
    public class QuantityMeasurementAuthService : IAuthService
    {
        private readonly IQuantityMeasurementRepository _repo;

        public QuantityMeasurementAuthService(IQuantityMeasurementRepository repo)
        {
            _repo = repo;
        }

        public string Register(RegisterDTO user)
        {
            if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Phone))
            {
                throw new QuantityMeasurementException("Username,Email,password and Phone Number cannot be empty.");
            }

            var newUser = new UserEntity
            {
                UserName = user.Username,
                Email=user.Email,
                Phone=user.Phone,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                CreatedAt = DateTime.Now
            };

            _repo.Register(newUser);
            return "success: user register";
        }

        public UserEntity? Login(LoginDTO user)
        {
            var User = _repo.GetUserbyEmail(user.Email);
            if(user != null && BCrypt.Net.BCrypt.Verify(user.Password,User.Password)) return User;
            return null;
        }

        public string GenerateJwtToken(UserEntity user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("THIS_IS_A_SUPER_SECRET_KEY_1234567890"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "QuantityMeasurementApp.Api",
                audience: "QuantityMeasurementApp.Api",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}