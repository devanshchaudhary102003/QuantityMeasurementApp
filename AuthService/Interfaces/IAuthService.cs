using AuthService.DTOs;
using AuthService.Models;

namespace AuthService.Interfaces
{
    public interface IAuthService
    {
        string Register(RegisterDTO user);
        UserEntity? Login(LoginDTO user);
        string GenerateJwtToken(UserEntity user);
        Task<UserEntity?> LoginWithGoogle(string idToken);
        UserEntity? GetUserById(int id);
    }
}
