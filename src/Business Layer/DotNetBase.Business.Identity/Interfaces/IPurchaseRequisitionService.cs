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
    public interface IPurchaseRequisitionService
    {
        Task<IEnumerable<PurchaseRequisition>> GetAllPurchaseRequisitionAsync();
        Task<PurchaseRequisition> GetPurchaseRequisitionByIdAsync(int id);
        Task<PurchaseRequisition> CreatePurchaseRequisitionAsync(CreatePurchaseRequisition createPurchaseRequisition);
        Task UpdatePurchaseRequisitionAsync(int id, UpdatePurchaseRequisition updatePurchaseRequisition);
        Task DeletePurchaseRequisitionAsync(int id);
    }
}
