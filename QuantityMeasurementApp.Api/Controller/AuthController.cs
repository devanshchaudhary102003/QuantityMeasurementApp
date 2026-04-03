using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppBusinessLayer.Service;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Entity;
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
            string token = _auth.GenerateJwtToken(user);
            return Ok(new {message = "Success: Login",user.UserName,token});
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDTO register)
        {
            string result = _auth.Register(register);
            return Ok(new {message = result});
        }

    
    }
}
