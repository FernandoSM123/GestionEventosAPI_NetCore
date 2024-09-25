using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface IRoleService
    {
        Task<Role> GetRoleByIdAsync(int id);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> CreateRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(int roleId, Role role);
        Task<bool> DeleteRoleAsync(int id);
    }
}
