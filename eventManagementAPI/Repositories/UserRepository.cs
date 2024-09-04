using eventManagementAPI.Data;
using eventManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using eventManagementAPI.Repositories.IRepositories;

namespace eventManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(u => u.userType).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.Include(u => u.userType).FirstOrDefaultAsync(u => u.id == id);
        }

        public async Task<IEnumerable<User>> GetPagedUsersAsync(int pageNumber, int pageSize, string filterField = null, string filterValue = null, string orderByField = null, bool ascending = true)
        {
            var query = _context.Users.Include(u => u.userType).AsQueryable();

            // Filtrado
            if (!string.IsNullOrEmpty(filterField) && !string.IsNullOrEmpty(filterValue))
            {
                query = query.Where(u => EF.Property<string>(u, filterField).Contains(filterValue));
            }

            // Ordenamiento
            if (!string.IsNullOrEmpty(orderByField))
            {
                query = ascending ? query.OrderBy(u => EF.Property<object>(u, orderByField)) : query.OrderByDescending(u => EF.Property<object>(u, orderByField));
            }

            // Paginación
            query = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return await query.ToListAsync();
        }


        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.userType)
                .FirstOrDefaultAsync(u => u.email == email);
        }
    }
}
