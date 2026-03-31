using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Entity;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using QuantityMeasurementAppRepositoryLayer.Interface;

namespace QuantityMeasurementApp.Api.Controller{

    [Route("/api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _auth;
        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var user = _auth.Login(login);
            if(user == null) return BadRequest(new {message = "Invalid Credentials"});
            string token = GenerateJwtToken(user);
            return Ok(new {message = "Success: Login",user.UserName,token});
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] LoginDTO register)
        {
            string result = _auth.Register(register);
            return Ok(new {message = result});
        }

        private string GenerateJwtToken(UserEntity user)
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
