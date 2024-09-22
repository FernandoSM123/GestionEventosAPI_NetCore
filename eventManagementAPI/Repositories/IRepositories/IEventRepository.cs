using eventManagementAPI.Models;

namespace eventManagementAPI.Repositories.IRepositories
{
    public interface IEventRepository
    {
        // Crear un evento
        Task AddEventAsync(Event newEvent);

        // Obtener un evento por id
        Task<Event> GetEventByIdAsync(int id);

        // Actualizar un evento
        void UpdateEvent(Event updatedEvent);

        // Eliminar un evento
        void DeleteEvent(Event eventToDelete);

        // Obtener todos los eventos
        Task<IEnumerable<Event>> GetAllEventsAsync();

        // Obtener eventos entre dos rangos de fecha
        Task<IEnumerable<Event>> GetEventsBetweenDatesAsync(DateTime startDate, DateTime endDate);

        // Guardar cambios
        Task<bool> SaveChangesAsync();
    }
}
