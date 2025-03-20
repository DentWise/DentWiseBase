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
    public class EmailThreadService : IEmailThreadService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailThreadService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmailThread> CreateEmailThreadAsync(CreateEmailThread createEmailThread)
        {
            if (createEmailThread.CompanyId == null || createEmailThread.ContactId == null)
                throw new Exception("CompanyId or ContactId cannot be null!");

            var emailThread = new EmailThread
            {
                Body = createEmailThread.Body,
                ContactId = createEmailThread.ContactId,
                CompanyId = createEmailThread.CompanyId,
                CreatedAt = DateTime.UtcNow,
                InReplyToMessageId = createEmailThread.InReplyToMessageId,
                MessageId = createEmailThread.MessageId,
                ReceivedDate = createEmailThread.ReceivedDate,
                SentDate = createEmailThread.SentDate,
                UserId = createEmailThread.UserId,
                Subject = createEmailThread.Subject,
                Direction = createEmailThread.Direction,
                Status = createEmailThread.Status,
                ReferencesMessageId = createEmailThread.ReferencesMessageId
            };

            await _unitOfWork.EmailThreadRepository.AddAsync(emailThread);
            await _unitOfWork.CompleteAsync();
            return emailThread;
        }

        public async Task<EmailThread> GetEmailThreadByIdAsync(int id)
        {
            var emailThread = await _unitOfWork.EmailThreadRepository.GetByIdAsync(id);
            if (emailThread == null)
                throw new Exception("Object not found!!");

            return emailThread;
        }
    }
}
