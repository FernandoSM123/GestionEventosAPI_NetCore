using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Métodos para Provincias
        public async Task<IEnumerable<Province>> GetProvincesAsync()
        {
            return await _unitOfWork.Locations.GetProvincesAsync();
        }

        // Métodos para Cantones
        public async Task<IEnumerable<Canton>> GetCantonsAsync()
        {
            return await _unitOfWork.Locations.GetCantonsAsync();
        }

        public async Task<IEnumerable<Canton>> GetCantonsByProvinceIdAsync(int provinceId)
        {
            return await _unitOfWork.Locations.GetCantonsByProvinceIdAsync(provinceId);
        }

        // Métodos para Distritos
        public async Task<IEnumerable<District>> GetDistrictsAsync()
        {
            return await _unitOfWork.Locations.GetDistrictsAsync();
        }

        public async Task<IEnumerable<District>> GetDistrictsByCantonIdAsync(int cantonId)
        {
            return await _unitOfWork.Locations.GetDistrictsByCantonIdAsync(cantonId);
        }
    }
}
