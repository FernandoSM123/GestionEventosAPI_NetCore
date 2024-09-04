using eventManagementAPI.DTOs;
using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<User> AuthenticateUserAsync(LoginDTO loginDto);
    }
}
