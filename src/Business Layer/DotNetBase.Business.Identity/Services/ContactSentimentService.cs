using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class ContactSentimentService : IContactSentimentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactSentimentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ContactSentiment> CreateContactSentimentAsync(CreateContactSentiment createContactSentiment)
        {
            var contactSentiment = new ContactSentiment
            {
                Name = createContactSentiment.Name,
                Feeling = createContactSentiment.Feeling,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ContactSentimentRepository.AddAsync(contactSentiment);
            await _unitOfWork.CompleteAsync();

            return contactSentiment;
        }

        public async Task DeleteContactSentimentAsync(int id)
        {
            var contactSentiment = await _unitOfWork.ContactSentimentRepository.GetByIdAsync(id);
            if (contactSentiment == null)
                throw new Exception("ContactSentiment not found!");

            contactSentiment.IsDeleted = true;
            contactSentiment.DeletedAt = DateTime.UtcNow;

            _unitOfWork.ContactSentimentRepository.Update(contactSentiment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ContactSentiment>> GetAllContactSentimentAsync()
        {
            var contactSentiments = await _unitOfWork.ContactSentimentRepository.FindManyAsync(u => !u.IsDeleted);
            if (contactSentiments == null)
                throw new Exception("ContactSetiment does not have any object!");

            return contactSentiments;
        }

        public async Task<ContactSentiment> GetContactSentimentByIdAsync(int id)
        {
            var contactSentiments = await _unitOfWork.ContactSentimentRepository.GetByIdAsync(id);
            if (contactSentiments == null || contactSentiments.IsDeleted)
                throw new Exception("Object not found!");

            return contactSentiments;
        }

        public async Task UpdateContactSentimentAsync(int id, UpdateContactSentiment updateContactSentiment)
        {
            var contactSentiments = await _unitOfWork.ContactSentimentRepository.GetByIdAsync(id);
            if (contactSentiments == null || contactSentiments.IsDeleted)
                throw new Exception("Object not found!");

            if (updateContactSentiment.Feeling != null)
                contactSentiments.Feeling = updateContactSentiment.Feeling;

            contactSentiments.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ContactSentimentRepository.Update(contactSentiments);
            await _unitOfWork.CompleteAsync();
        }
    }
}
