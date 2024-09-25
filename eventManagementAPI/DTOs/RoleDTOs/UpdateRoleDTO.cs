using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.RoleDTOs
{
    public class UpdateRoleDTO
    {
        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(100, ErrorMessage = "Role name can't be longer than 100 characters.")]
        public string name { get; set; }

        public string? descripcion { get; set; }
    }
}
