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
    public class PurchaseRequestConsolidationService : IPurchaseRequestConsolidationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseRequestConsolidationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseRequestConsolidation> CreatePurchaseRequestConsolidationAsync(CreatePurchaseRequestConsolidation createPurchaseRequestConsolidation)
        {
            if (createPurchaseRequestConsolidation.ConsolidationNumber == null)
                throw new Exception("ConsolidationNumber can not be null!");

            var purchaseRequestConsolidation = new PurchaseRequestConsolidation
            {
                ConsolidationDate = createPurchaseRequestConsolidation.ConsolidationDate,
                ConsolidationNumber = createPurchaseRequestConsolidation.ConsolidationNumber,
                ConsolidationStatusId = createPurchaseRequestConsolidation?.ConsolidationStatusId,
                CreatedAt = DateTime.UtcNow,
                Description = createPurchaseRequestConsolidation?.Description,
            };
            await _unitOfWork.PurchaseRequestConsolidationRepository.AddAsync(purchaseRequestConsolidation);
            await _unitOfWork.CompleteAsync();
            return purchaseRequestConsolidation;
        }

        public async Task DeletePurchaseRequestConsolidationAsync(int id)
        {
            var purchaseRequestConsolidation = await _unitOfWork.PurchaseRequestConsolidationRepository.GetByIdAsync(id);
            if (purchaseRequestConsolidation == null)
                throw new Exception("PurchaseRequestConsolidation not found!");

            purchaseRequestConsolidation.IsDeleted = true;
            purchaseRequestConsolidation.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PurchaseRequestConsolidationRepository.Update(purchaseRequestConsolidation);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PurchaseRequestConsolidation>> GetAllPurchaseRequestConsolidationAsync()
        {
            var purchaseRequestConsolidation = await _unitOfWork.PurchaseRequestConsolidationRepository.FindManyAsync(u => !u.IsDeleted);
            if (purchaseRequestConsolidation == null)
                throw new Exception("PurchaseRequestConsolidation does not have any object!");

            return purchaseRequestConsolidation;
        }

        public async Task<PurchaseRequestConsolidation> GetPurchaseRequestConsolidationByIdAsync(int id)
        {
            var purchaseRequestConsolidation = await _unitOfWork.PurchaseRequestConsolidationRepository.GetByIdAsync(id);
            if (purchaseRequestConsolidation == null || purchaseRequestConsolidation.IsDeleted)
                throw new Exception("Object not found!");

            return purchaseRequestConsolidation;
        }

        public async Task UpdatePurchaseRequestConsolidationAsync(int id, UpdatePurchaseRequestConsolidation updatePurchaseRequestConsolidation)
        {
            var purchaseRequestConsolidation = await _unitOfWork.PurchaseRequestConsolidationRepository.GetByIdAsync(id);
            if (purchaseRequestConsolidation == null || purchaseRequestConsolidation.IsDeleted)
                throw new Exception("Object not found!");


            if (updatePurchaseRequestConsolidation.ConsolidationDate != null)
                purchaseRequestConsolidation.ConsolidationDate = updatePurchaseRequestConsolidation.ConsolidationDate;
            if (updatePurchaseRequestConsolidation.ConsolidationStatusId != null)
                purchaseRequestConsolidation.ConsolidationStatusId = updatePurchaseRequestConsolidation.ConsolidationStatusId;
            if (updatePurchaseRequestConsolidation.ConsolidationNumber != null)
                purchaseRequestConsolidation.ConsolidationNumber = updatePurchaseRequestConsolidation.ConsolidationNumber;
            if (updatePurchaseRequestConsolidation.Description != null)
                purchaseRequestConsolidation.Description = updatePurchaseRequestConsolidation.Description;

            purchaseRequestConsolidation.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.PurchaseRequestConsolidationRepository.Update(purchaseRequestConsolidation);
            await _unitOfWork.CompleteAsync();
        }
    }
}
