using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<EFCore.Entities.Task>> GetAllTaskAsync();
        Task<EFCore.Entities.Task> GetTaskByIdAsync(int id);
        Task<EFCore.Entities.Task> CreateTaskAsync(CreateTask createTask);
        System.Threading.Tasks.Task UpdateTaskAsync(int id, UpdateTask updateTask);
        System.Threading.Tasks.Task DeleteTaskAsync(int id);
    }
}
