using Business.DTOs;

namespace Business.Interfaces
{
    public interface IAuthService
    {
        Task<string> GenerateToken(string username, string role = "");
        Task<LoginResponse?> Login(LoginRequest request);
    }
}
