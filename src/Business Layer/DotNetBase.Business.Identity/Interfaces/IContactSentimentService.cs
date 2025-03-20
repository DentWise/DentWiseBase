using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IContactSentimentService
    {
        Task<IEnumerable<ContactSentiment>> GetAllContactSentimentAsync();
        Task<ContactSentiment> GetContactSentimentByIdAsync(int id);
        Task<ContactSentiment> CreateContactSentimentAsync(CreateContactSentiment createContactSentiment);
        Task UpdateContactSentimentAsync(int id, UpdateContactSentiment updateContactSentiment);
        Task DeleteContactSentimentAsync(int id);
    }
}
