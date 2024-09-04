using AutoMapper;
using eventManagementAPI.DTOs;
using eventManagementAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

            var user = await _authService.AuthenticateUserAsync(loginDto);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            // Aquí puedes generar un token JWT o cualquier otro mecanismo de autenticación que uses
            return Ok(new { Message = "Login successful", User = userDTO });
        }
    }
}
