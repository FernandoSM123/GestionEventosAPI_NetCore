using eventManagementAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.LocationDTOs
{
    public class DistrictDTO
    {
        public int id { get; set; }
        public int code { get; set; }

        public string name { get; set; }

        public int cantonId { get; set; }
    }
}
