using Microsoft.AspNetCore.Identity;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppBusinessLayer.Exception;
using QuantityMeasurementAppRepositoryLayer.Interface;
using QuantityMeasurementAppRepositoryLayer.Database;
using QuantityMeasurementAppModelLayer.Entity;
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

        public string Register(LoginDTO user)
        {
            var newUser = new UserEntity
            {
                UserName = user.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                CreatedAt = DateTime.Now
            };

            _repo.Register(newUser);
            return "success: user register";
        }

        public UserEntity? Login(LoginDTO user)
        {
            var User = _repo.GetUserbyName(user.Username);
            if(user != null && BCrypt.Net.BCrypt.Verify(user.Password,User.Password)) return User;
            return null;
        }

    }
}