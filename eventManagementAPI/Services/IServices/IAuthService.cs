using eventManagementAPI.DTOs;
using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<(string, User)> AuthenticateUserAsync(LoginDTO loginDto);
        Task LogoutAsync(int userId);
    }
}
