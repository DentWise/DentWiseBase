using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IQuotationApprovalStatusService
    {
        Task<IEnumerable<QuotationApprovalStatus>> GetAllQuotationApprovalStatusAsync();
        Task<QuotationApprovalStatus> GetQuotationApprovalStatusByIdAsync(int id);
        Task<QuotationApprovalStatus> CreateQuotationApprovalStatusAsync(CreateQuotationApprovalStatus createQuotationApprovalStatus);
        Task UpdateQuotationApprovalStatusAsync(int id, UpdateQuotationApprovalStatus updateQuotationApprovalStatus);
        Task DeleteQuotationApprovalStatusAsync(int id);
    }
}
