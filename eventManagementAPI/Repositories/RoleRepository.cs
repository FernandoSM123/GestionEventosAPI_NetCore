using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Obtener Rol por Id
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        // Obtener todos los Roles
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        // Crear un nuevo Rol
        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        // Actualizar un Rol existente
        public async Task UpdateRoleAsync(Role role)
        {
            _context.Roles.Update(role);
        }

        // Eliminar un Rol
        public async Task DeleteRoleAsync(Role role)
        {
                _context.Roles.Remove(role);
        }

        // Confirmar los cambios
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
