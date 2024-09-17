namespace eventManagementAPI.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Lastname { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public UserTypeDTO UserType { get; set; }
    }
}
