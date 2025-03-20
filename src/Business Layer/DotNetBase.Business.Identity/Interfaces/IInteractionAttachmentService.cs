using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IInteractionAttachmentService
    {
        Task<IEnumerable<InteractionAttachment>> GetAllInteractionAttachmentAsync();
        Task<InteractionAttachment> GetInteractionAttachmentByIdAsync(int id);
        Task<InteractionAttachment> CreateInteractionAttachmentAsync(CreateInteractionAttachment createInteractionAttachment);
        Task DeleteInteractionAttachmentAsync(int id);
    }
}
