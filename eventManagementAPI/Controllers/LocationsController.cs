using AutoMapper;
using eventManagementAPI.DTOs.LocationDTOs;
using eventManagementAPI.DTOs.UserDTOs;
using eventManagementAPI.Models;
using eventManagementAPI.Services;
using eventManagementAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        // Métodos para Provincias

        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var provinces = await _locationService.GetProvincesAsync();
            var provincesDTOs = _mapper.Map<IEnumerable<ProvinceDTO>>(provinces);
            return Ok(provincesDTOs);
        }

        // Métodos para Cantones

        [HttpGet("cantons")]
        public async Task<IActionResult> GetCantons()
        {
            var cantons = await _locationService.GetCantonsAsync();
            var cantonsDTOs = _mapper.Map<IEnumerable<CantonDTO>>(cantons);
            return Ok(cantonsDTOs);
        }

        [HttpGet("cantons/{provinceId}")]
        public async Task<IActionResult> GetCantonsByProvinceId(int provinceId)
        {
            var cantons = await _locationService.GetCantonsByProvinceIdAsync(provinceId);
            var cantonsDTOs = _mapper.Map<IEnumerable<CantonDTO>>(cantons);
            return Ok(cantonsDTOs);
        }

        // Métodos para Distritos

        [HttpGet("districts")]
        public async Task<IActionResult> GetDistricts()
        {
            var districts = await _locationService.GetDistrictsAsync();
            var districtsDTOs = _mapper.Map<IEnumerable<DistrictDTO>>(districts);
            return Ok(districtsDTOs);
        }

        [HttpGet("districts/{cantonId}")]
        public async Task<IActionResult> GetDistrictsByCantonId(int cantonId)
        {
            var districts = await _locationService.GetDistrictsByCantonIdAsync(cantonId);
            var districtsDTOs = _mapper.Map<IEnumerable<DistrictDTO>>(districts);
            return Ok(districtsDTOs);
        }
    }
}
