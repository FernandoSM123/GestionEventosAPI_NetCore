using eventManagementAPI.Repositories.IRepositories;
using eventManagementAPI.Repositories;

namespace eventManagementAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IRoleRepository _roleRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);
        public ITokenRepository Tokens => _tokenRepository ?? new TokenRepository(_context);
        public ILocationRepository Locations => _locationRepository ?? new LocationRepository(_context);
        public IEventRepository Events => _eventRepository ?? new EventRepository(_context);
        public IRoleRepository Roles => _roleRepository ?? new RoleRepository(_context);

        public async Task<bool> CompleteAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
