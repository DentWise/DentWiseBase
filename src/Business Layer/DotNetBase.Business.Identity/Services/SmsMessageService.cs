using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;

namespace DotNetBase.Business.Identity.Services
{
    public class SmsMessageService : ISmsMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SmsMessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SmsMessage> CreateSmsMessageAsync(CreateSmsMessage createSmsMessage)
        {
            if (createSmsMessage.CompanyId == null || createSmsMessage.ContactId == null)
                throw new Exception("CompanyId or ContactId can not be null!");

            var smsMessage = new SmsMessage
            {
                ContactId = createSmsMessage.ContactId,
                CompanyId = createSmsMessage.CompanyId,
                CreatedAt = DateTime.UtcNow,
                Direction = createSmsMessage.Direction,
                MessageText = createSmsMessage.MessageText,
                PhoneNumber = createSmsMessage.PhoneNumber,
                ProviderMessageId = createSmsMessage.ProviderMessageId,
                SentDate = createSmsMessage.SentDate,
                ReceivedDate = createSmsMessage.ReceivedDate,
                Status = createSmsMessage.Status,
                UserId = createSmsMessage.UserId
            };

            await _unitOfWork.SmsMessageRepository.AddAsync(smsMessage);
            await _unitOfWork.CompleteAsync();
            return smsMessage;
        }

        public async Task<IEnumerable<SmsMessage>> GetAllSmsMessageAsync()
        {
            var smsMessage = await _unitOfWork.SmsMessageRepository.GetAllAsync();
            if (smsMessage == null)
                throw new Exception("SmsMessage does not have any object!");

            return smsMessage;
        }

        public async Task<SmsMessage> GetSmsMessageByIdAsync(int id)
        {
            var smsMessage = await _unitOfWork.SmsMessageRepository.GetByIdAsync(id);
            if (smsMessage == null)
                throw new Exception("Object not found!");

            return smsMessage;
        }
    }
}
