using eventManagementAPI.Models;

namespace eventManagementAPI.Repositories.IRepositories
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Role role);
        Task<bool> SaveChangesAsync();
    }
}
