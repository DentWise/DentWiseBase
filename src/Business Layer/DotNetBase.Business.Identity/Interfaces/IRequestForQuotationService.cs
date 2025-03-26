using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IRequestForQuotationService
    {
        Task<IEnumerable<RequestForQuotation>> GetAllRequestForQuotationAsync();
        Task<RequestForQuotation> GetRequestForQuotationByIdAsync(int id);
        Task<RequestForQuotation> CreateRequestForQuotationAsync(CreateRequestForQuotation createRequestForQuotation);
        Task UpdateRequestForQuotationAsync(int id, UpdateRequestForQuotation updateRequestForQuotation);
        Task DeleteRequestForQuotationAsync(int id);
    }
}
