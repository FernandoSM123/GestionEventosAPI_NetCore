using AutoMapper;
using eventManagementAPI.DTOs;
using eventManagementAPI.Models;
using eventManagementAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace eventManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedUsers(int pageNumber = 1, int pageSize = 10, string filterField = null, string filterValue = null, string orderByField = null, bool ascending = true)
        {
            var users = await _userService.GetPagedUsersAsync(pageNumber, pageSize, filterField, filterValue, orderByField, ascending);
            var userDTOs = _mapper.Map<IEnumerable<UserDTO>>(users);
            return Ok(userDTOs);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO createUserDTO)
        {
            //verificar validaciones
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mapper.Map<User>(createUserDTO);

            try
            {
                var createdUser = await _userService.CreateUserAsync(user);
                var createdUserDTO = _mapper.Map<UserDTO>(createdUser);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUserDTO.Id }, createdUserDTO);
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            // Verificar si el modelo es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Obtener el usuario existente por ID
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Verificar si el correo electrónico ya está en uso por otro usuario
            if (!string.IsNullOrWhiteSpace(updateUserDTO.Email) && existingUser.email != updateUserDTO.Email)
            {
                // Si el correo ha cambiado, verificar si ya existe
                var emailExists = await _userService.EmailExistsAsync(updateUserDTO.Email);
                if (emailExists)
                {
                    ModelState.AddModelError("Email", "Email already exists.");
                    return BadRequest(ModelState);
                }
            }

            // Mapear el DTO al modelo de usuario existente
            _mapper.Map(updateUserDTO, existingUser);

            // Encriptar la contraseña si se proporciona una nueva
            if (!string.IsNullOrWhiteSpace(updateUserDTO.Password))
            {
                existingUser.password = BCrypt.Net.BCrypt.HashPassword(updateUserDTO.Password);
            }

            try
            {
                var success = await _userService.UpdateUserAsync(id, existingUser);
                if (!success)
                {
                    return BadRequest("User could not be updated");
                }
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("Email", ex.Message);
                return BadRequest(ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
