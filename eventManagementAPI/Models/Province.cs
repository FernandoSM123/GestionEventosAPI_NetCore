using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.Models
{
    public class Province
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        public ICollection<Canton> cantons { get; set; }

        public ICollection<Event> events { get; set; }
    }
}
