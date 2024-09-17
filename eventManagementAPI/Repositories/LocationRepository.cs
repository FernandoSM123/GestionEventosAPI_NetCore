using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Métodos para Provincias
        public async Task<IEnumerable<Province>> GetProvincesAsync()
        {
            return await _context.Provinces.ToListAsync();
        }

        // Métodos para Cantones
        public async Task<IEnumerable<Canton>> GetCantonsAsync()
        {
            return await _context.Cantons.ToListAsync();
        }

        public async Task<IEnumerable<Canton>> GetCantonsByProvinceIdAsync(int provinceId)
        {
            return await _context.Cantons.Where(c => c.provinceId == provinceId).ToListAsync();
        }

        // Métodos para Distritos
        public async Task<IEnumerable<District>> GetDistrictsAsync()
        {
            return await _context.Districts.ToListAsync();
        }

        public async Task<IEnumerable<District>> GetDistrictsByCantonIdAsync(int cantonId)
        {
            return await _context.Districts.Where(d => d.cantonId == cantonId).ToListAsync();
        }

        // Confirmar los cambios en la base de datos
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
