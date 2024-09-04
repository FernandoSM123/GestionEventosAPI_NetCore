using eventManagementAPI.Data;
using eventManagementAPI.DTOs;
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

        public async Task<IEnumerable<User>> GetPagedUsersAsync(int pageNumber, int pageSize, string filterField = null, string filterValue = null, string orderByField = null, bool ascending = true)
        {
            return await _unitOfWork.Users.GetPagedUsersAsync(pageNumber, pageSize, filterField, filterValue, orderByField, ascending);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            if (await EmailExistsAsync(user.email))
            {
                throw new InvalidOperationException("Email already exists.");
            }

            // Encriptar la contraseña antes de guardar el usuario
            user.password = BCrypt.Net.BCrypt.HashPassword(user.password);

            await _unitOfWork.Users.AddUserAsync(user);
            var success = await _unitOfWork.CompleteAsync();
            if (!success)
            {
                return null;
            }

            var createdUser = await _unitOfWork.Users.GetUserByIdAsync(user.id);
            return createdUser;
        }

        public async Task<bool> UpdateUserAsync(int id, User user)
        {
            // Verificar si el usuario existe por ID primero
            var userToUpdate = await _unitOfWork.Users.GetUserByIdAsync(id);
            if (userToUpdate == null)
            {
                return false;
            }

            // Verificar si el correo existe y pertenece a otro usuario
            var existingUser = await _unitOfWork.Users.GetUserByEmailAsync(user.email);
            if (existingUser != null && existingUser.id != id)
            {
                throw new InvalidOperationException("Email already exists.");
            }

            // Actualizar las propiedades del usuario existente
            userToUpdate.username = user.username;
            userToUpdate.lastname = user.lastname;
            userToUpdate.cellphone = user.cellphone;
            userToUpdate.email = user.email;
            userToUpdate.password = user.password;
            userToUpdate.userTypeId = user.userTypeId;

            _unitOfWork.Users.UpdateUser(userToUpdate);
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

        public async Task<bool> EmailExistsAsync(string email)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(email);
            return user != null;
        }
    }
}
