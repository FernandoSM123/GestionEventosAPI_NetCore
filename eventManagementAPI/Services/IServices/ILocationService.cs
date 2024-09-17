using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface ILocationService
    {
        // Métodos para Provincias
        Task<IEnumerable<Province>> GetProvincesAsync();

        // Métodos para Cantones
        Task<IEnumerable<Canton>> GetCantonsAsync();
        Task<IEnumerable<Canton>> GetCantonsByProvinceIdAsync(int provinceId);

        // Métodos para Distritos
        Task<IEnumerable<District>> GetDistrictsAsync();
        Task<IEnumerable<District>> GetDistrictsByCantonIdAsync(int cantonId);
    }
}
