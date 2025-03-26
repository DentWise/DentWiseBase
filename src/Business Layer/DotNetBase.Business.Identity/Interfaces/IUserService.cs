using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(CreateUser createUser);
        Task UpdateUserAsync(int id, UpdateUser updateUser);
        Task DeleteUserAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
    }
}
