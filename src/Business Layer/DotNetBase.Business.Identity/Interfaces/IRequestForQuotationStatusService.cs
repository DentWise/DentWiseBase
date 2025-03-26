using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IRequestForQuotationStatusService
    {
        Task<IEnumerable<RequestForQuotationStatus>> GetAllRequestForQuotationStatusAsync();
        Task<RequestForQuotationStatus> GetRequestForQuotationStatusByIdAsync(int id);
        Task<RequestForQuotationStatus> CreateRequestForQuotationStatusAsync(CreateRequestForQuotationStatus createRequestForQuotationStatus);
        Task UpdateRequestForQuotationStatusAsync(int id, UpdateRequestForQuotationStatus updateRequestForQuotationStatus);
        Task DeleteRequestForQuotationStatusAsync(int id);
    }
}
