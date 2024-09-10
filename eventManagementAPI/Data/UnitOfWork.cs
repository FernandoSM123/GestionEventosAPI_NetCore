using eventManagementAPI.Repositories.IRepositories;
using eventManagementAPI.Repositories;

namespace eventManagementAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly ITokenRepository _tokenRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ?? new UserRepository(_context);
        public ITokenRepository Tokens => _tokenRepository ?? new TokenRepository(_context);

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
