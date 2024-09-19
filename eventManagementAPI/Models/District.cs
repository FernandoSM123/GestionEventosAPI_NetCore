using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventManagementAPI.Models
{
    public class District
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int code { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        public int cantonId { get; set; }

        [ForeignKey("cantonId")]
        public Canton canton { get; set; }

        public ICollection<Event> events { get; set; }
    }
}
