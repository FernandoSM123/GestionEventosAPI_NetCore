using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Repositories.IRepositories;
using eventManagementAPI.Services.IServices;

namespace eventManagementAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Obtener un Rol por Id
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetRoleByIdAsync(id);
            if (role == null)
            {
                return null;
            }
            return role;
        }

        // Obtener todos los Roles
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _unitOfWork.Roles.GetAllRolesAsync();
        }

        // Crear un nuevo Rol
        public async Task<Role> CreateRoleAsync(Role role)
        {
            await _unitOfWork.Roles.AddRoleAsync(role);
            var success = await _unitOfWork.Roles.SaveChangesAsync();

            if (!success)
            {
                return null;
            }
            var createdRole = await _unitOfWork.Roles.GetRoleByIdAsync(role.id);
            return createdRole;
        }

        // Actualizar un Rol existente
        public async Task<Role> UpdateRoleAsync(int roleId, Role role)
        {
            var existingRole = await _unitOfWork.Roles.GetRoleByIdAsync(roleId);
            if (existingRole == null)
            {
                return null;
            }

            // Actualiza las propiedades
            existingRole.name = role.name;
            existingRole.descripcion = role.descripcion;

            await _unitOfWork.Roles.UpdateRoleAsync(existingRole);
            await _unitOfWork.Roles.SaveChangesAsync();

            return existingRole;
        }

        // Eliminar un Rol por Id
        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _unitOfWork.Roles.GetRoleByIdAsync(id);
            if (role == null)
            {
                return false;
            }

            await _unitOfWork.Roles.DeleteRoleAsync(role);
            await _unitOfWork.Roles.SaveChangesAsync();
            return true;
        }
    }
}
