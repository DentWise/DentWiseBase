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
    public interface IRequisitionItemService
    {
        Task<IEnumerable<RequisitionItem>> GetAllRequisitionItemAsync();
        Task<RequisitionItem> GetRequisitionItemByIdAsync(int id);
        Task<RequisitionItem> CreateRequisitionItemAsync(CreateRequisitionItem createRequisitionItem);
        Task UpdateRequisitionItemAsync(int id, UpdateRequisitionItem updateRequisitionItem);
        Task DeleteRequisitionItemAsync(int id);
    }
}
