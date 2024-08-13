using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Services.IServices;

namespace eventManagementAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _unitOfWork.Users.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.Users.GetUserByIdAsync(id);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _unitOfWork.Users.AddUserAsync(user);
            var success = await _unitOfWork.CompleteAsync();
            return success ? user : null;
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            var existingUser = await _unitOfWork.Users.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return false;
            }

            existingUser.username = user.username;
            existingUser.lastname = user.lastname;
            existingUser.cellphone = user.cellphone;
            existingUser.email = user.email;
            existingUser.password = user.password;
            existingUser.userTypeId = user.userTypeId;

            _unitOfWork.Users.UpdateUser(existingUser);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Users.GetUserByIdAsync(id);
            if (user == null)
            {
                return false;
            }

            _unitOfWork.Users.DeleteUser(user);
            return await _unitOfWork.CompleteAsync();
        }
    }
}
