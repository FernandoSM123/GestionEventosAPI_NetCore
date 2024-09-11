using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.Models
{
    public class Token
    {
        [Key]
        public int id { get; set; }  // ID del token

        [Required]
        public string jwtToken { get; set; }  // El token JWT generado

        [Required]
        public DateTime expiration { get; set; }  // Fecha de expiración del token

        [Required]
        public bool isRevoked { get; set; }  // Si el token ha sido revocado

        [Required]
        public int userId { get; set; }  // Relación con el usuario que tiene este token

        [ForeignKey("UserId")] 
        public User user { get; set; }  // Propiedad de navegación al usuario
    }
}
