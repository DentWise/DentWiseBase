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
    public class PurchaseRequisitionService : IPurchaseRequisitionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseRequisitionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseRequisition> CreatePurchaseRequisitionAsync(CreatePurchaseRequisition createPurchaseRequisition)
        {
            if (createPurchaseRequisition.RequisitionNumber == null)
                throw new Exception("RequisitionNumber can not be null!");

            var purchaseRequisition = new PurchaseRequisition
            {
                RequisitionNumber = createPurchaseRequisition.RequisitionNumber,
                ApprovalNotes = createPurchaseRequisition.ApprovalNotes,
                CreatedAt = DateTime.UtcNow,
                DeliveryCompanyAddressId = createPurchaseRequisition.DeliveryCompanyAddressId,
                Description = createPurchaseRequisition.Description,
                RequesterCompanyId = createPurchaseRequisition.RequesterCompanyId,
                RequesterUserId = createPurchaseRequisition.RequesterUserId,
                RequisitionDate = createPurchaseRequisition.RequisitionDate,
                RequisitionStatusId = createPurchaseRequisition.RequisitionStatusId
            };
            await _unitOfWork.PurchaseRequisitionRepository.AddAsync(purchaseRequisition);
            await _unitOfWork.CompleteAsync();
            return purchaseRequisition;
        }

        public async Task DeletePurchaseRequisitionAsync(int id)
        {
            var purchaseRequisition = await _unitOfWork.PurchaseRequisitionRepository.GetByIdAsync(id);
            if (purchaseRequisition == null)
                throw new Exception("PurchaseRequisition not found!");

            purchaseRequisition.IsDeleted = true;
            purchaseRequisition.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PurchaseRequisitionRepository.Update(purchaseRequisition);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PurchaseRequisition>> GetAllPurchaseRequisitionAsync()
        {
            var purchaseRequisition = await _unitOfWork.PurchaseRequisitionRepository.FindManyAsync(u => !u.IsDeleted);
            if (purchaseRequisition == null)
                throw new Exception("PurchaseRequisition does not have any object!");

            return purchaseRequisition;
        }

        public async Task<PurchaseRequisition> GetPurchaseRequisitionByIdAsync(int id)
        {
            var purchaseRequisition = await _unitOfWork.PurchaseRequisitionRepository.GetByIdAsync(id);
            if (purchaseRequisition == null || purchaseRequisition.IsDeleted)
                throw new Exception("Object not found!");

            return purchaseRequisition;
        }

        public async Task UpdatePurchaseRequisitionAsync(int id, UpdatePurchaseRequisition updatePurchaseRequisition)
        {
            var purchaseRequisition = await _unitOfWork.PurchaseRequisitionRepository.GetByIdAsync(id);
            if (purchaseRequisition == null || purchaseRequisition.IsDeleted)
                throw new Exception("Object not found!");


            if (updatePurchaseRequisition.RequisitionDate != null)
                purchaseRequisition.RequisitionDate = updatePurchaseRequisition.RequisitionDate;
            if (updatePurchaseRequisition.ApprovalNotes != null)
                purchaseRequisition.ApprovalNotes = updatePurchaseRequisition.ApprovalNotes;
            if (updatePurchaseRequisition.RequisitionStatusId != null)
                purchaseRequisition.RequisitionStatusId = updatePurchaseRequisition.RequisitionStatusId;
            if (updatePurchaseRequisition.Description != null)
                purchaseRequisition.Description = updatePurchaseRequisition.Description;

            purchaseRequisition.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.PurchaseRequisitionRepository.Update(purchaseRequisition);
            await _unitOfWork.CompleteAsync();
        }
    }
}
