using AutoMapper;
using eventManagementAPI.DTOs.EventDTOs;
using eventManagementAPI.DTOs.UserDTOs;
using eventManagementAPI.Models;
using eventManagementAPI.Services;
using eventManagementAPI.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eventManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        // 1. Crear un evento
        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventDTO createEventDTO)
        {
            //verificar validaciones
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventObj = _mapper.Map<Event>(createEventDTO);
            var createdEvent = await _eventService.CreateEventAsync(eventObj);
            if (createdEvent == null)
            {
                return StatusCode(500, "An error occurred while creating the event.");
            }

            var eventDTO = _mapper.Map<EventDTO>(createdEvent);
            return CreatedAtAction(nameof(GetEventById), new { id = eventDTO.id }, eventDTO);
        }

        // 2. Obtener un evento por id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var eventObj = await _eventService.GetEventByIdAsync(id);
            if (eventObj == null)
            {
                return NotFound($"Event with ID {id} not found.");
            }
            var eventDTO = _mapper.Map<EventDTO>(eventObj);
            return Ok(eventDTO);
        }

        // 3. Actualizar un evento por id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, [FromBody] UpdateEventDTO updateEventDTO)
        {
            // Verificar si el modelo es válido
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eventDTO = _mapper.Map<Event>(updateEventDTO);
            bool result = await _eventService.UpdateEventAsync(id, eventDTO);
            if (!result)
            {
                return NotFound($"Event with ID {id} not found or could not be updated.");
            }

            return NoContent();
        }

        // 4. Eliminar un evento por id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            bool result = await _eventService.DeleteEventAsync(id);
            if (!result)
            {
                return NotFound($"Event with ID {id} not found.");
            }

            return NoContent(); // 204 No Content indicates the deletion was successful.
        }

        // 5. Obtener todos los eventos
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _eventService.GetAllEventsAsync();
            var eventsDTO = _mapper.Map<IEnumerable<EventDTO>>(events);
            return Ok(eventsDTO);
        }

        // 6. Obtener una lista de eventos entre dos rangos de fechas
        [HttpGet("between-dates")]
        public async Task<IActionResult> GetEventsBetweenDates([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date must be before end date.");
            }

            var events = await _eventService.GetEventsBetweenDatesAsync(startDate, endDate);
            var eventsDTO = _mapper.Map<IEnumerable<EventDTO>>(events);
            return Ok(eventsDTO);
        }
    }
}
