using eventManagementAPI.DTOs;
using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetPagedUsersAsync(int pageNumber, int pageSize, string filterField = null, string filterValue = null, string orderByField = null, bool ascending = true);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(int id, User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
