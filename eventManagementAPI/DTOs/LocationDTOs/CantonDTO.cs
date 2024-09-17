using eventManagementAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.LocationDTOs
{
    public class CantonDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public int provinceId { get; set; }
    }
}
