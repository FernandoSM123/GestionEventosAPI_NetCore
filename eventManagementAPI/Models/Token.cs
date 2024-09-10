namespace eventManagementAPI.Models
{
    public class Token
    {
        public int id { get; set; }          // ID del token
        public string jwtToken { get; set; } // El token JWT generado
        public DateTime expiration { get; set; } // Fecha de expiración del token
        public bool isRevoked { get; set; }  // Si el token ha sido revocado
        public int userId { get; set; }      // Relación con el usuario que tiene este token
        public User user { get; set; }       // Propiedad de navegación al usuario
    }
}
