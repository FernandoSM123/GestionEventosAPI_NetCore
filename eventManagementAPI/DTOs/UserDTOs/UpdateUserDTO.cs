using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.UserDTOs
{
    public class UpdateUserDTO
    {
        [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters.")]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "Lastname can't be longer than 50 characters.")]
        public string Lastname { get; set; }

        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Cellphone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        public int UserTypeId { get; set; }
    }
}
