using eventManagementAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using eventManagementAPI.DTOs.LocationDTOs;

namespace eventManagementAPI.DTOs.EventDTOs
{
    public class EventDTO
    {
        //detalles basicos evento
        public int id { get; set; }

        public string name { get; set; }

        public string? description { get; set; }

        public string? details { get; set; }

        //detalles de lugar
        public string exactPlace { get; set; }

        public ProvinceDTO province { get; set; }

        public CantonDTO canton { get; set; }

        public DistrictDTO district { get; set; }


        //detalles de hora y dia
        public TimeSpan startingTime { get; set; }

        public TimeSpan finishingTime { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }
    }
}
