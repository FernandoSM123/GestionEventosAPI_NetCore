using eventManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.LocationDTOs
{
    public class ProvinceDTO
    {
        public int id { get; set; }
        public int code { get; set; }

        public string name { get; set; }
    }
}
