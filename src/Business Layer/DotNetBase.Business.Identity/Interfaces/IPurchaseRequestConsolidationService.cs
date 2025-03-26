using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IPurchaseRequestConsolidationService
    {
        Task<IEnumerable<PurchaseRequestConsolidation>> GetAllPurchaseRequestConsolidationAsync();
        Task<PurchaseRequestConsolidation> GetPurchaseRequestConsolidationByIdAsync(int id);
        Task<PurchaseRequestConsolidation> CreatePurchaseRequestConsolidationAsync(CreatePurchaseRequestConsolidation createPurchaseRequestConsolidation);
        Task UpdatePurchaseRequestConsolidationAsync(int id, UpdatePurchaseRequestConsolidation updatePurchaseRequestConsolidation);
        Task DeletePurchaseRequestConsolidationAsync(int id);
    }
}
