using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IPurchaseRequisitionConsolidationItemsLinkService
    {
        Task<IEnumerable<PurchaseRequisitionConsolidationItemsLink>> GetAllPurchaseRequisitionConsolidationItemsLinkAsync();
        Task<PurchaseRequisitionConsolidationItemsLink> GetPurchaseRequisitionConsolidationItemsLinkByIdAsync(int id);
        Task<PurchaseRequisitionConsolidationItemsLink> CreatePurchaseRequisitionConsolidationItemsLinkAsync(CreatePurchaseRequisitionConsolidationItemsLink createPurchaseRequisitionConsolidationItemsLink);
        Task UpdatePurchaseRequisitionConsolidationItemsLinkAsync(int id, UpdatePurchaseRequisitionConsolidationItemsLink updatePurchaseRequisitionConsolidationItemsLink);
        Task DeletePurchaseRequisitionConsolidationItemsLinkAsync(int id);
    }
}
