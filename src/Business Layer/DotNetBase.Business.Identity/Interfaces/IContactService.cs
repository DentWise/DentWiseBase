using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(CreateContact createContact);
        Task UpdateContactAsync(int id, UpdateContact updateContact);
        Task DeleteContactAsync(int id);
    }
}
