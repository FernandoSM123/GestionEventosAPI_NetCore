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
        public async Task<IActionResult> CreateUser(User user)
        {
            var createdUser = await _userService.CreateUserAsync(user);
            if (createdUser == null)
            {
                return BadRequest("User could not be created");
            }
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            var success = await _userService.UpdateUserAsync(id, user);
            if (!success)
            {
                return NotFound();
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
