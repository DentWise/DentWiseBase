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
    public interface IPurchaseOrderStatusService
    {
        Task<IEnumerable<PurchaseOrderStatus>> GetAllPurchaseOrderStatusAsync();
        Task<PurchaseOrderStatus> GetPurchaseOrderStatusByIdAsync(int id);
        Task<PurchaseOrderStatus> CreatePurchaseOrderStatusAsync(CreatePurchaseOrderStatus createPurchaseOrderStatus);
        Task UpdatePurchaseOrderStatusAsync(int id, UpdatePurchaseOrderStatus updatePurchaseOrderStatus);
        Task DeletePurchaseOrderStatusAsync(int id);
    }
}
