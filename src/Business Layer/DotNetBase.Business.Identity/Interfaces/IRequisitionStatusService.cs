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
    public interface IRequisitionStatusService
    {
        Task<IEnumerable<RequisitionStatus>> GetAllRequisitionStatusAsync();
        Task<RequisitionStatus> GetRequisitionStatusByIdAsync(int id);
        Task<RequisitionStatus> CreateRequisitionStatusAsync(CreateRequisitionStatus createRequisitionStatus);
        Task UpdateRequisitionStatusAsync(int id, UpdateRequisitionStatus updateRequisitionStatus);
        Task DeleteRequisitionStatusAsync(int id);
    }
}
