using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(50)]
        public string username { get; set; }

        [Required]
        [MaxLength(50)] 
        public string lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public string cellphone { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string email { get; set; }

        [Required]
        [MaxLength(255)]
        public string password { get; set; }

        [Required]
        public int userTypeId { get; set; }

        // Definición de la relación con UserType
        [ForeignKey("userTypeId")]
        public UserType userType { get; set; }

        // Relación con los tokens generados para este usuario
        public ICollection<Token> Tokens { get; set; } = new List<Token>();
    }
}
