using AutoMapper;
using eventManagementAPI.DTOs;
using eventManagementAPI.DTOs.UserDTOs;
using eventManagementAPI.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (token, user) = await _authService.AuthenticateUserAsync(loginDto);

            // Caso 1: El usuario no fue encontrado o las credenciales son incorrectas
            if (user == null)
            {
                return Unauthorized("Incorrect credentials");
            }

            // Caso 2: El usuario fue autenticado pero no se pudo generar el token
            if (token == null)
            {
                return StatusCode(500, "Unable to generate token. Please try again.");
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(new { Message = "Login successful", User = userDTO, Token = token });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            // Extraer el userId de los claims del token JWT
            var userId = int.Parse(User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
            await _authService.LogoutAsync(userId);
            return Ok(new { Message = "Logout successful. All tokens have been removed." });
        }
    }
}
