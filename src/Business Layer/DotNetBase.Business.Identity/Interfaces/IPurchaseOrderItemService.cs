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
    public interface IPurchaseOrderItemService
    {
        Task<IEnumerable<PurchaseOrderItem>> GetAllPurchaseOrderItemAsync();
        Task<PurchaseOrderItem> GetPurchaseOrderItemByIdAsync(int id);
        Task<PurchaseOrderItem> CreatePurchaseOrderItemAsync(CreatePurchaseOrderItem createPurchaseOrderItem);
        Task UpdatePurchaseOrderItemAsync(int id, UpdatePurchaseOrderItem updatePurchaseOrderItem);
        Task DeletePurchaseOrderItemAsync(int id);
    }
}
