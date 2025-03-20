using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class ConsolidationStatusService : IConsolidationStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsolidationStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ConsolidationStatus> CreateConsolidationStatusAsync(CreateConsolidationStatus createConsolidationStatus)
        {
            if (createConsolidationStatus.StatusName == null)
                throw new Exception("StatusName can not be null!");

            var consolidationStatus = new ConsolidationStatus
            {
                StatusName = createConsolidationStatus.StatusName,
                CreatedAt = DateTime.UtcNow,
                Description = createConsolidationStatus.Description,
                IsDefault = createConsolidationStatus.IsDefault
            };

            await _unitOfWork.ConsolidationStatusRepository.AddAsync(consolidationStatus);
            await _unitOfWork.CompleteAsync();

            return consolidationStatus;
        }

        public async Task DeleteConsolidationStatusAsync(int id)
        {
            var consolidationStatus = await _unitOfWork.ConsolidationStatusRepository.GetByIdAsync(id);
            if (consolidationStatus == null)
                throw new Exception("ConsolidationStatus not found!");

            consolidationStatus.IsDeleted = true;
            consolidationStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.ConsolidationStatusRepository.Update(consolidationStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ConsolidationStatus>> GetAllConsolidationStatusAsync()
        {
            var consolidationStatus = await _unitOfWork.ConsolidationStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (consolidationStatus == null)
                throw new Exception("ConsolidationStatus does not have any object!");
            return consolidationStatus;
        }

        public async Task<ConsolidationStatus> GetConsolidationStatusByIdAsync(int id)
        {
            var consolidationStatus = await _unitOfWork.ConsolidationStatusRepository.GetByIdAsync(id);
            if (consolidationStatus == null || consolidationStatus.IsDeleted)
                throw new Exception("Object not found!");

            return consolidationStatus;
        }

        public async Task UpdateConsolidationStatusAsync(int id, UpdateConsolidationStatus updateConsolidationStatus)
        {
            var consolidationStatus = await _unitOfWork.ConsolidationStatusRepository.GetByIdAsync(id);
            if (consolidationStatus == null || consolidationStatus.IsDeleted)
                throw new Exception("Object not found!");


            if (updateConsolidationStatus.StatusName != null)
                consolidationStatus.StatusName = updateConsolidationStatus.StatusName;
            if (updateConsolidationStatus.IsDefault != null)
                consolidationStatus.IsDefault = updateConsolidationStatus.IsDefault;
            if (updateConsolidationStatus.Description != null)
                consolidationStatus.Description = updateConsolidationStatus.Description;

            consolidationStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ConsolidationStatusRepository.Update(consolidationStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
