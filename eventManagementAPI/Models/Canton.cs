using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eventManagementAPI.Models
{
    public class Canton
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int code { get; set; }

        [Required]
        [MaxLength(50)]
        public string name { get; set; }

        [Required]
        public int provinceId { get; set; }

        [ForeignKey("provinceId")]
        public Province province { get; set; }

        public ICollection<District> districts { get; set; }

        public ICollection<Event> events { get; set; }
    }
}
