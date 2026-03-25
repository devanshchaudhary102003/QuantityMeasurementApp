using QuantityMeasurementAppModelLayer.DTOs;
using QuantityMeasurementAppModelLayer.Models;

namespace QuantityMeasurementAppBusinessLayer.Interface
{
    public interface IAuthService
    {
        string Register(LoginDTO user);
        UserEntity? Login(LoginDTO user);
    }
}