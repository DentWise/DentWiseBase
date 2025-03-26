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
    public class PurchaseOrderStatusService : IPurchaseOrderStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrderStatus> CreatePurchaseOrderStatusAsync(CreatePurchaseOrderStatus createPurchaseOrderStatus)
        {
            if (createPurchaseOrderStatus.StatusName == null)
                throw new Exception("StatusName can not be null!");

            var purchaseOrderStatus = new PurchaseOrderStatus
            {
                StatusName = createPurchaseOrderStatus.StatusName,
                CreatedAt = DateTime.UtcNow,
                Description = createPurchaseOrderStatus.Description,
                IsDefault = createPurchaseOrderStatus.IsDefault
            };

            await _unitOfWork.PurchaseOrderStatusRepository.AddAsync(purchaseOrderStatus);
            await _unitOfWork.CompleteAsync();

            return purchaseOrderStatus;
        }

        public async Task DeletePurchaseOrderStatusAsync(int id)
        {
            var purchaseOrderStatus = await _unitOfWork.PurchaseOrderStatusRepository.GetByIdAsync(id);
            if (purchaseOrderStatus == null)
                throw new Exception("PurchaseOrderStatus not found!");

            purchaseOrderStatus.IsDeleted = true;
            purchaseOrderStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PurchaseOrderStatusRepository.Update(purchaseOrderStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PurchaseOrderStatus>> GetAllPurchaseOrderStatusAsync()
        {
            var purchaseOrderStatus = await _unitOfWork.PurchaseOrderStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (purchaseOrderStatus == null)
                throw new Exception("PurchaseOrderStatus does not have any object!");

            return purchaseOrderStatus;
        }

        public async Task<PurchaseOrderStatus> GetPurchaseOrderStatusByIdAsync(int id)
        {
            var purchaseOrderStatus = await _unitOfWork.PurchaseOrderStatusRepository.GetByIdAsync(id);
            if (purchaseOrderStatus == null || purchaseOrderStatus.IsDeleted)
                throw new Exception("Object not found!");

            return purchaseOrderStatus;
        }

        public async Task UpdatePurchaseOrderStatusAsync(int id, UpdatePurchaseOrderStatus updatePurchaseOrderStatus)
        {
            var purchaseOrderStatus = await _unitOfWork.PurchaseOrderStatusRepository.GetByIdAsync(id);
            if (purchaseOrderStatus == null || purchaseOrderStatus.IsDeleted)
                throw new Exception("Object not found!");


            if (updatePurchaseOrderStatus.StatusName != null)
                purchaseOrderStatus.StatusName = updatePurchaseOrderStatus.StatusName;
            if (updatePurchaseOrderStatus.IsDefault != null)
                purchaseOrderStatus.IsDefault = updatePurchaseOrderStatus.IsDefault;
            if (updatePurchaseOrderStatus.Description != null)
                purchaseOrderStatus.Description = updatePurchaseOrderStatus.Description;

            purchaseOrderStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.PurchaseOrderStatusRepository.Update(purchaseOrderStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
