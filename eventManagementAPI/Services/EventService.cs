using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Services.IServices;

namespace eventManagementAPI.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Crear un evento
        public async Task<Event> CreateEventAsync(Event newEvent)
        {
            // Aquí puedes agregar lógica adicional si es necesario
            await _unitOfWork.Events.AddEventAsync(newEvent);
            var  success = await _unitOfWork.Events.SaveChangesAsync();

            if (!success) {
                return null;
            }
            var createdEvent = await _unitOfWork.Events.GetEventByIdAsync(newEvent.id);
            return createdEvent;
        }

        // Obtener un evento por id
        public async Task<Event> GetEventByIdAsync(int id)
        {
            var eventObj = await _unitOfWork.Events.GetEventByIdAsync(id);
            if (eventObj == null)
            {
                return null;
            }
            return eventObj;
        }

        // Actualizar un evento
        public async Task<bool> UpdateEventAsync(int id, Event updatedEvent)
        {
            var existingEvent = await _unitOfWork.Events.GetEventByIdAsync(id);
            if (existingEvent == null)
            {
                return false; // No se encontró el evento para actualizar
            }

            // Actualizar los campos del evento existente
            existingEvent.name = updatedEvent.name;
            existingEvent.description = updatedEvent.description;
            existingEvent.details = updatedEvent.details;
            existingEvent.exactPlace = updatedEvent.exactPlace;
            existingEvent.provinceId = updatedEvent.provinceId;
            existingEvent.cantonId = updatedEvent.cantonId;
            existingEvent.districtId = updatedEvent.districtId;
            existingEvent.startingTime = updatedEvent.startingTime;
            existingEvent.finishingTime = updatedEvent.finishingTime;
            existingEvent.startDate = updatedEvent.startDate;
            existingEvent.endDate = updatedEvent.endDate;

            _unitOfWork.Events.UpdateEvent(existingEvent);
            return await _unitOfWork.Events.SaveChangesAsync();
        }

        // Eliminar un evento
        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventToDelete = await _unitOfWork.Events.GetEventByIdAsync(id);
            if (eventToDelete == null)
            {
                return false; // No se encontró el evento para eliminar
            }

            _unitOfWork.Events.DeleteEvent(eventToDelete);
            return await _unitOfWork.Events.SaveChangesAsync();
        }

        // Obtener todos los eventos
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _unitOfWork.Events.GetAllEventsAsync();
        }

        // Obtener eventos entre dos fechas
        public async Task<IEnumerable<Event>> GetEventsBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _unitOfWork.Events.GetEventsBetweenDatesAsync(startDate, endDate);
        }
    }
}
