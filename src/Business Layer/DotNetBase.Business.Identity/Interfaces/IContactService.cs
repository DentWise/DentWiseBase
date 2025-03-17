using DotNetBase.Entities.Dto.RequestModels;
using DotNetBase.Entities.Identity;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(CreateContactDto createContact);
        Task UpdateContactAsync(int id, UpdateContactDto updateContact);
        Task DeleteContactAsync(int id);
    }
}
