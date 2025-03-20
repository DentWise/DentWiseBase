using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IPaymentStatusService
    {
        Task<IEnumerable<PaymentStatus>> GetAllPaymentStatusAsync();
        Task<PaymentStatus> GetPaymentStatusByIdAsync(int id);
        Task<PaymentStatus> CreatePaymentStatusAsync(CreatePaymentStatus createPaymentStatus);
        Task UpdatePaymentStatusAsync(int id, UpdatePaymentStatus updatePaymentStatus);
        Task DeletePaymentStatusAsync(int id);
    }
}
