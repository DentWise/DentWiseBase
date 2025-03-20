using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IInteractionTypeService
    {
        Task<IEnumerable<InteractionType>> GetAllInteractionTypeAsync();
        Task<InteractionType> GetInteractionTypeByIdAsync(int id);
        Task<InteractionType> CreateInteractionTypeAsync(CreateInteractionType createInteractionType);
        Task UpdateInteractionTypeAsync(int id, UpdateInteractionType updateInteractionType);
        Task DeleteInteractionTypeAsync(int id);
    }
}
