using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear un nuevo evento
        public async Task AddEventAsync(Event newEvent)
        {
            await _context.Events.AddAsync(newEvent);
        }

        // Obtener un evento por id
        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _context.Events
                .Include(e => e.province)  // Incluir la relación con Province
                .Include(e => e.canton)    // Incluir la relación con Canton
                .Include(e => e.district)  // Incluir la relación con District
                .FirstOrDefaultAsync(e => e.id == id);
        }

        // Actualizar un evento
        public void UpdateEvent(Event updatedEvent)
        {
            _context.Events.Update(updatedEvent);
        }

        // Eliminar un evento
        public void DeleteEvent(Event eventToDelete)
        {
            _context.Events.Remove(eventToDelete);
        }

        // Obtener todos los eventos
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _context.Events
                .Include(e => e.province)
                .Include(e => e.canton)
                .Include(e => e.district)
                .ToListAsync();
        }

        // Obtener eventos entre dos fechas
        public async Task<IEnumerable<Event>> GetEventsBetweenDatesAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Events
                .Where(e => e.startDate >= startDate && e.endDate <= endDate)
                .Include(e => e.province)
                .Include(e => e.canton)
                .Include(e => e.district)
                .ToListAsync();
        }

        // Guardar cambios
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
