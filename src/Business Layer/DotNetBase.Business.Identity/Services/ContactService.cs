using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModels;
using DotNetBase.Entities.Identity;

namespace DotNetBase.Business.Identity.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contact> CreateContactAsync(CreateContactDto createContact)
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
            return contacts;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(id);
            if (contact == null || contact.IsDeleted)
                throw new Exception("Object not found!!");

            return contact;
        }

        public async Task UpdateContactAsync(int id, UpdateContactDto updateContact)
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

            if (updateContact.FirstName != null)
                contact.FirstName = updateContact.FirstName;
            if (updateContact.Email != null)
                contact.Email = updateContact.Email;
            if(updateContact.LastName != null)
                contact.LastName = updateContact.LastName;
            if(updateContact.PhoneNumber != null)
                contact.PhoneNumber = updateContact.PhoneNumber;
            if(updateContact.Position != null)
                contact.Position = updateContact.Position;

            contact.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ContactRepository.Update(contact);
            await _unitOfWork.CompleteAsync();
        }
    }
}
