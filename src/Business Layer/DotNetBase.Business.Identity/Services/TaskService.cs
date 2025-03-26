using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;

namespace DotNetBase.Business.Identity.Services
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TaskService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EFCore.Entities.Task> CreateTaskAsync(CreateTask createTask)
        {
            if (createTask.UserId == null)
                throw new Exception("UserId can not be null!");

            var task = new EFCore.Entities.Task
            {
                UserId = createTask.UserId,
                CompanyId = createTask.CompanyId,
                ContactId = createTask.ContactId,
                CreatedAt = DateTime.UtcNow,
                DueDate = createTask.DueDate,
                InteractionId = createTask.InteractionId,
                TaskDescription = createTask.TaskDescription,
                TaskTitle = createTask.TaskTitle
            };

            await _unitOfWork.TaskRepository.AddAsync(task);
            await _unitOfWork.CompleteAsync();
            return task;
        }

        public async System.Threading.Tasks.Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EFCore.Entities.Task>> GetAllTaskAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EFCore.Entities.Task> GetTaskByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async System.Threading.Tasks.Task UpdateTaskAsync(int id, UpdateTask updateTask)
        {
            throw new NotImplementedException();
        }
    }
}
