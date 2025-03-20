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
    public interface IConsolidatedRequisitionItemService
    {
        Task<IEnumerable<ConsolidatedRequisitionItem>> GetAllConsolidatedRequisitionItemAsync();
        Task<ConsolidatedRequisitionItem> GetConsolidatedRequisitionItemByIdAsync(int id);
        Task<ConsolidatedRequisitionItem> CreateConsolidatedRequisitionItemAsync(CreateConsolidatedRequisitionItem createConsolidatedRequisitionItem);
        Task UpdateConsolidatedRequisitionItemAsync(int id, UpdateConsolidatedRequisitionItem updateConsolidatedRequisitionItem);
        Task DeleteConsolidatedRequisitionItemAsync(int id);
    }
}
