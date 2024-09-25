using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.Models
{
    public class Role
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }

        public string? descripcion { get; set; }
    }
}
