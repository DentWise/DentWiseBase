using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ISmsMessageService
    {
        Task<IEnumerable<SmsMessage>> GetAllSmsMessageAsync();
        Task<SmsMessage> GetSmsMessageByIdAsync(int id);
        Task<SmsMessage> CreateSmsMessageAsync(CreateSmsMessage createSmsMessage);
    }
}
