using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.Models
{
    public class UserType
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string name { get; set; }

        public string? description { get; set; }

        public ICollection<User> users { get; set; }

    }
}
