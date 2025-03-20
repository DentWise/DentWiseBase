using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IClinicPaymentService
    {
        Task<IEnumerable<ClinicPayment>> GetAllClinicPaymentAsync();
        Task<ClinicPayment> GetClinicPaymentByIdAsync(int id);
        Task<ClinicPayment> CreateClinicPaymentAsync(CreateClinicPayment createClinicPayment);
        Task UpdateClinicPaymentAsync(int id, UpdateClinicPayment updateClinicPayment);
        Task DeleteClinicPaymentAsync(int id);
    }
}
