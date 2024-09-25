using eventManagementAPI.Repositories.IRepositories;

namespace eventManagementAPI.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITokenRepository Tokens { get; }
        ILocationRepository Locations { get; }
        IEventRepository Events { get; }
        IRoleRepository Roles { get; }
        Task<bool> CompleteAsync();
    }
}
