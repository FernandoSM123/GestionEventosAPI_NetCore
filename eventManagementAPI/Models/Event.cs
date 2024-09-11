using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.Models
{
    public class Event
    {
        //detalles basicos evento
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string? description { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string?  details { get; set; }

        //detalles de lugar
        [Required]
        [MaxLength(100)]
        public string exactPlace { get; set; }

        [Required]
        public int provinceId { get; set; }

        [ForeignKey("provinceId")]
        public Province province { get; set; }

        [Required]
        public int cantonId { get; set; }

        [ForeignKey("cantonId")]
        public Canton canton { get; set; }

        [Required]
        public int districtId { get; set; }

        [ForeignKey("districtId")]
        public District district { get; set; }


        //detalles de hora y dia
        [Required]
        public TimeSpan startingTime { get; set; }

        [Required]
        public TimeSpan finishingTime { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime endDate { get; set; }
    }
}
