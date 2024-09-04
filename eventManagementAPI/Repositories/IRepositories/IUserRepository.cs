using eventManagementAPI.DTOs;
using eventManagementAPI.Models;

namespace eventManagementAPI.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetPagedUsersAsync(int pageNumber, int pageSize, string filterField = null, string filterValue = null, string orderByField = null, bool ascending = true);
        Task AddUserAsync(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> SaveChangesAsync();
        Task<User> GetUserByEmailAsync(string email);
    }
}
