using eventManagementAPI.Repositories.IRepositories;

namespace eventManagementAPI.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITokenRepository Tokens { get; }
        ILocationRepository Locations { get; }
        Task<bool> CompleteAsync();
    }
}
