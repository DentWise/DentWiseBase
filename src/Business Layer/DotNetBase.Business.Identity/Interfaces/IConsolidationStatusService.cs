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
    public interface IConsolidationStatusService
    {
        Task<IEnumerable<ConsolidationStatus>> GetAllConsolidationStatusAsync();
        Task<ConsolidationStatus> GetConsolidationStatusByIdAsync(int id);
        Task<ConsolidationStatus> CreateConsolidationStatusAsync(CreateConsolidationStatus createConsolidationStatus);
        Task UpdateConsolidationStatusAsync(int id, UpdateConsolidationStatus updateConsolidationStatus);
        Task DeleteConsolidationStatusAsync(int id);
    }
}
