using eventManagementAPI.Data;
using eventManagementAPI.DTOs;
using eventManagementAPI.Models;
using eventManagementAPI.Services.IServices;

namespace eventManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AuthenticateUserAsync(LoginDTO loginDto)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return null; // Usuario no encontrado
            }

            // Verificar la contraseña
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.password);
            if (!isPasswordValid)
            {
                return null; // Contraseña incorrecta
            }

            return user; // Autenticación exitosa
        }
    }
}
