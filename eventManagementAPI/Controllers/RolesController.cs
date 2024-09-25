using AutoMapper;
using eventManagementAPI.DTOs.EventDTOs;
using eventManagementAPI.DTOs.RoleDTOs;
using eventManagementAPI.Models;
using eventManagementAPI.Services;
using eventManagementAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RolesController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        // Obtener un Rol por Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            var roleDTO = _mapper.Map<RoleDTO>(role);
            return Ok(roleDTO);
        }

        // Obtener todos los Roles
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            var rolesDTO = _mapper.Map<IEnumerable<RoleDTO>>(roles);
            return Ok(rolesDTO);
        }

        // Crear un nuevo Rol
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDTO createRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newRole = _mapper.Map<Role>(createRoleDTO);
            var createdRole = await _roleService.CreateRoleAsync(newRole);

            var roleDTO = _mapper.Map<RoleDTO>(createdRole);
            return CreatedAtAction(nameof(GetRoleById), new { id = roleDTO.id }, roleDTO);
        }

        // Actualizar un Role existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleDTO updateRoleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var roleDTO = _mapper.Map<Role>(updateRoleDTO);
            var result = await _roleService.UpdateRoleAsync(id, roleDTO);
            if (result == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        // Eliminar un Rol por Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
