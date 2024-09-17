using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.UserDTOs
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username can't be longer than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [StringLength(50, ErrorMessage = "Lastname can't be longer than 50 characters.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Cellphone is required.")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "UserTypeId is required.")]
        public int UserTypeId { get; set; }
    }
}
