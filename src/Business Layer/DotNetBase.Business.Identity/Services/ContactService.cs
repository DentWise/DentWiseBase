using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contact> CreateContactAsync(CreateContact createContact)
        {
            if (createContact.CompanyId == null)
                throw new Exception("Company area cannot null!");

            var contactExist = await _unitOfWork.ContactRepository.FindOneAsync(x => x.Email == createContact.Email && x.PhoneNumber == createContact.PhoneNumber);
            if (contactExist != null)
                throw new Exception("Email and phone number are used!");

            var newContact = new Contact
            {
                PhoneNumber = createContact.PhoneNumber,
                Email = createContact.Email,
                CompanyId = createContact.CompanyId,
                CreatedAt = DateTime.UtcNow,
                FirstName = createContact.FirstName,
                LastName = createContact.LastName,
                Position = createContact.Position
            };
            await _unitOfWork.ContactRepository.AddAsync(newContact);
            await _unitOfWork.CompleteAsync();

            return newContact;
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(id);
            if (contact == null)
                throw new Exception("Contact not found!");

            contact.IsDeleted = true;
            contact.DeletedAt = DateTime.UtcNow;

            _unitOfWork.ContactRepository.Update(contact);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            var contacts = await _unitOfWork.ContactRepository.FindManyAsync(u => !u.IsDeleted);
            if (contacts == null)
                throw new Exception("Contact does not have any object!");

            return contacts;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(id);
            if (contact == null || contact.IsDeleted)
                throw new Exception("Object not found!!");

            return contact;
        }

        public async Task UpdateContactAsync(int id, UpdateContact updateContact)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(id);
            if (contact == null || contact.IsDeleted)
                throw new Exception("Object not found!!");

            if (!string.IsNullOrEmpty(updateContact.Email) && updateContact.Email != contact.Email)
            {
                var existingContact = await _unitOfWork.ContactRepository.FindOneAsync(u => u.Email == updateContact.Email && u.Id != id && !u.IsDeleted);
                if (existingContact != null)
                    throw new InvalidOperationException("A contact with this email already exists.");
            }

            if (updateContact.Email != null)
                contact.Email = updateContact.Email;
            if (updateContact.PhoneNumber != null)
                contact.PhoneNumber = updateContact.PhoneNumber;
            if (updateContact.Position != null)
                contact.Position = updateContact.Position;

            contact.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ContactRepository.Update(contact);
            await _unitOfWork.CompleteAsync();
        }
    }
}
