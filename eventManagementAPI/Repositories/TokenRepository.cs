using eventManagementAPI.Data;
using eventManagementAPI.Models;
using eventManagementAPI.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace eventManagementAPI.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;

        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        //Anadir token a la DB
        public async Task AddTokenAsync(Token token)
        {
            await _context.Tokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        //Obtener token
        public async Task<Token> GetTokenAsync(string jwtToken)
        {
            return await _context.Tokens.FirstOrDefaultAsync(t => t.jwtToken == jwtToken);
        }

        // Eliminar todos los tokens asociados a un usuario
        public async Task RemoveAllTokensForUserAsync(int userId)
        {
            var tokens = _context.Tokens.Where(t => t.userId == userId);
            _context.Tokens.RemoveRange(tokens);
            await _context.SaveChangesAsync();
        }
    }
}
