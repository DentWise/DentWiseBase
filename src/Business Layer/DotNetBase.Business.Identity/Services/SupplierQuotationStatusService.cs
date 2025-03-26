using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class SupplierQuotationStatusService : ISupplierQuotationStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierQuotationStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierQuotationStatus> CreateSupplierQuotationStatusAsync(CreateSupplierQuotationStatus createSupplierQuotationStatus)
        {
            if (createSupplierQuotationStatus.StatusName == null)
                throw new Exception("StatusName can not be null!");

            var supplierQuotationStatus = new SupplierQuotationStatus
            {
                StatusName = createSupplierQuotationStatus.StatusName,
                Description = createSupplierQuotationStatus.Description,
                CreatedAt = DateTime.UtcNow,
                IsDefault = createSupplierQuotationStatus.IsDefault
            };

            await _unitOfWork.SupplierQuotationStatusRepository.AddAsync(supplierQuotationStatus);
            await _unitOfWork.CompleteAsync();
            return supplierQuotationStatus;
        }

        public async Task DeleteSupplierQuotationStatusAsync(int id)
        {
            var supplierQuotationStatus = await _unitOfWork.SupplierQuotationStatusRepository.GetByIdAsync(id);
            if (supplierQuotationStatus == null)
                throw new Exception("SupplierQuotationStatus not found!");

            supplierQuotationStatus.IsDeleted = true;
            supplierQuotationStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.SupplierQuotationStatusRepository.Update(supplierQuotationStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SupplierQuotationStatus>> GetAllSupplierQuotationStatusAsync()
        {
            var supplierQuotationStatus = await _unitOfWork.SupplierQuotationStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (supplierQuotationStatus == null)
                throw new Exception("SupplierQuotationStatus does not have any object!");

            return supplierQuotationStatus;
        }

        public async Task<SupplierQuotationStatus> GetSupplierQuotationStatusByIdAsync(int id)
        {
            var supplierQuotationStatus = await _unitOfWork.SupplierQuotationStatusRepository.GetByIdAsync(id);
            if (supplierQuotationStatus == null || supplierQuotationStatus.IsDeleted)
                throw new Exception("Object not found!");

            return supplierQuotationStatus;
        }

        public async Task UpdateSupplierQuotationStatusAsync(int id, UpdateSupplierQuotationStatus updateSupplierQuotationStatus)
        {
            var supplierQuotationStatus = await _unitOfWork.SupplierQuotationStatusRepository.GetByIdAsync(id);
            if (supplierQuotationStatus == null || supplierQuotationStatus.IsDeleted)
                throw new Exception("Object not found!");


            if (updateSupplierQuotationStatus.IsDefault != null)
                supplierQuotationStatus.IsDefault = updateSupplierQuotationStatus.IsDefault;
            if (updateSupplierQuotationStatus.StatusName != null)
                supplierQuotationStatus.StatusName = updateSupplierQuotationStatus.StatusName;
            if (updateSupplierQuotationStatus.Description != null)
                supplierQuotationStatus.Description = updateSupplierQuotationStatus.Description;

            supplierQuotationStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.SupplierQuotationStatusRepository.Update(supplierQuotationStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
