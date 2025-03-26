using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class RequisitionStatusService : IRequisitionStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequisitionStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequisitionStatus> CreateRequisitionStatusAsync(CreateRequisitionStatus createRequisitionStatus)
        {
            if (createRequisitionStatus.StatusName == null)
                throw new Exception("StatusName can not be null!");

            var requisitionStatus = new RequisitionStatus
            {
                StatusName = createRequisitionStatus.StatusName,
                CreatedAt = DateTime.UtcNow,
                Description = createRequisitionStatus.Description,
                IsDefault = createRequisitionStatus.IsDefault,
            };

            await _unitOfWork.RequisitionStatusRepository.AddAsync(requisitionStatus);
            await _unitOfWork.CompleteAsync();
            return requisitionStatus;
        }

        public async Task DeleteRequisitionStatusAsync(int id)
        {
            var requisitionStatus = await _unitOfWork.RequisitionStatusRepository.GetByIdAsync(id);
            if (requisitionStatus == null)
                throw new Exception("RequisitionStatus not found!");

            requisitionStatus.IsDeleted = true;
            requisitionStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.RequisitionStatusRepository.Update(requisitionStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<RequisitionStatus>> GetAllRequisitionStatusAsync()
        {
            var requisitionStatus = await _unitOfWork.RequisitionStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (requisitionStatus == null)
                throw new Exception("RequisitionStatus does not have any object!");

            return requisitionStatus;
        }

        public async Task<RequisitionStatus> GetRequisitionStatusByIdAsync(int id)
        {
            var requisitionStatus = await _unitOfWork.RequisitionStatusRepository.GetByIdAsync(id);
            if (requisitionStatus == null || requisitionStatus.IsDeleted)
                throw new Exception("Object not found!");

            return requisitionStatus;
        }

        public async Task UpdateRequisitionStatusAsync(int id, UpdateRequisitionStatus updateRequisitionStatus)
        {
            var requisitionStatus = await _unitOfWork.RequisitionStatusRepository.GetByIdAsync(id);
            if (requisitionStatus == null || requisitionStatus.IsDeleted)
                throw new Exception("Object not found!");


            if (updateRequisitionStatus.Description != null)
                requisitionStatus.Description = updateRequisitionStatus.Description;
            if (updateRequisitionStatus.IsDefault != null)
                requisitionStatus.IsDefault = updateRequisitionStatus.IsDefault;
            if (updateRequisitionStatus.StatusName != null)
                requisitionStatus.StatusName = updateRequisitionStatus.StatusName;

            requisitionStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.RequisitionStatusRepository.Update(requisitionStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
