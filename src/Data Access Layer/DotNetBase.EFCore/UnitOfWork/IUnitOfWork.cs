using DotNetBase.EFCore.Repositories;
using DotNetBase.Entities.Identity;

namespace DotNetBase.EFCore.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; } // Örnek repository
        IRepository<Role> RoleRepository { get; } // Örnek repository
        Task<int> CompleteAsync();
    }
}
