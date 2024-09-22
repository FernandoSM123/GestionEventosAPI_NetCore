using eventManagementAPI.Models;

namespace eventManagementAPI.Services.IServices
{
    public interface IEventService
    {
        // Crear un evento
        Task<Event> CreateEventAsync(Event newEvent);

        // Obtener un evento por id
        Task<Event> GetEventByIdAsync(int id);

        // Actualizar un evento
        Task<bool> UpdateEventAsync(int id, Event updatedEvent);

        // Eliminar un evento
        Task<bool> DeleteEventAsync(int id);

        // Obtener todos los eventos
        Task<IEnumerable<Event>> GetAllEventsAsync();

        // Obtener eventos entre dos fechas
        Task<IEnumerable<Event>> GetEventsBetweenDatesAsync(DateTime startDate, DateTime endDate);
    }
}
