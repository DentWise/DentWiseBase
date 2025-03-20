using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IEmailThreadService
    {
        Task<EmailThread> GetEmailThreadByIdAsync(int id);
        Task<EmailThread> CreateEmailThreadAsync(CreateEmailThread createEmailThread);
    }
}
