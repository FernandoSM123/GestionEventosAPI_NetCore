using eventManagementAPI.Repositories.IRepositories;

namespace eventManagementAPI.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        Task<bool> CompleteAsync();
    }
}
