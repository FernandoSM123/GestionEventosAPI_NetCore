using System.ComponentModel.DataAnnotations;

namespace eventManagementAPI.DTOs.RoleDTOs
{
    public class RoleDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string? descripcion { get; set; }
    }
}
