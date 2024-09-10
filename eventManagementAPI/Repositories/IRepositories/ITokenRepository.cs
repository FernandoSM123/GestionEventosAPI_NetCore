using eventManagementAPI.Models;

namespace eventManagementAPI.Repositories.IRepositories
{
    public interface ITokenRepository
    {
        Task AddTokenAsync(Token token);
        Task<Token> GetTokenAsync(string jwtToken);
        Task RemoveAllTokensForUserAsync(int userId);
    }
}
