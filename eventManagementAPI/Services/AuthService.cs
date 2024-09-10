using eventManagementAPI.Data;
using eventManagementAPI.DTOs;
using eventManagementAPI.Models;
using eventManagementAPI.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eventManagementAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
        }

        public async Task<(string, User)> AuthenticateUserAsync(LoginDTO loginDto)
        {
            var user = await _unitOfWork.Users.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return (null, null); // Usuario no encontrado
            }

            // Verificar la contraseña
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.password);
            if (!isPasswordValid)
            {
                return (null, null); // Contraseña incorrecta
            }

            // Autenticación exitosa, generar el token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Email, user.email),
                    // Puedes agregar más claims según sea necesario
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            // Guardar el token en la base de datos
            var tokenModel = new Token
            {
                jwtToken = tokenString,
                expiration = tokenDescriptor.Expires ?? DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes),
                userId = user.id,
                isRevoked = false
            };

            await _unitOfWork.Tokens.AddTokenAsync(tokenModel);

            return (tokenString, user); // Retorna el token y el usuario autenticado
        }

        // Método para eliminar todos los tokens del usuario
        public async Task LogoutAsync(int userId)
        {
            await _unitOfWork.Tokens.RemoveAllTokensForUserAsync(userId);
        }
    }
}
