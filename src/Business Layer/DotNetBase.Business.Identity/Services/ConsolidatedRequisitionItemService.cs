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
    public class ConsolidatedRequisitionItemService : IConsolidatedRequisitionItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsolidatedRequisitionItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ConsolidatedRequisitionItem> CreateConsolidatedRequisitionItemAsync(CreateConsolidatedRequisitionItem createConsolidatedRequisitionItem)
        {
            if (createConsolidatedRequisitionItem.ProductId == null || createConsolidatedRequisitionItem.PurchaseRequestConsolidationId == null)
                throw new Exception("ProductId or PurchaseRequestConsolidationId can not be null!");

            var consolidationRequisitionItem = new ConsolidatedRequisitionItem
            {
                ProductId = createConsolidatedRequisitionItem.ProductId,
                PurchaseRequestConsolidationId = createConsolidatedRequisitionItem.PurchaseRequestConsolidationId,
                Description = createConsolidatedRequisitionItem.Description,
                Quantity = createConsolidatedRequisitionItem.Quantity,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.ConsolidatedRequisitionItemRepository.AddAsync(consolidationRequisitionItem);
            await _unitOfWork.CompleteAsync();

            return consolidationRequisitionItem;
        }

        public async Task DeleteConsolidatedRequisitionItemAsync(int id)
        {
            var consolidatedRequisitionItem = await _unitOfWork.ConsolidatedRequisitionItemRepository.GetByIdAsync(id);
            if (consolidatedRequisitionItem == null)
                throw new Exception("ConsolidatedRequisitionItem not found!");

            consolidatedRequisitionItem.IsDeleted = true;
            consolidatedRequisitionItem.DeletedAt = DateTime.UtcNow;

            _unitOfWork.ConsolidatedRequisitionItemRepository.Update(consolidatedRequisitionItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ConsolidatedRequisitionItem>> GetAllConsolidatedRequisitionItemAsync()
        {
            var consolidatedRequisitionItem = await _unitOfWork.ConsolidatedRequisitionItemRepository.FindManyAsync(u => !u.IsDeleted);
            return consolidatedRequisitionItem;
        }

        public async Task<ConsolidatedRequisitionItem> GetConsolidatedRequisitionItemByIdAsync(int id)
        {
            var consolidatedRequisitionItem = await _unitOfWork.ConsolidatedRequisitionItemRepository.GetByIdAsync(id);
            if (consolidatedRequisitionItem == null || consolidatedRequisitionItem.IsDeleted)
                throw new Exception("ConsolidatedRequisitionItem does not have any object!");

            return consolidatedRequisitionItem;
        }

        public async Task UpdateConsolidatedRequisitionItemAsync(int id, UpdateConsolidatedRequisitionItem updateConsolidatedRequisitionItem)
        {
            var consolidatedRequisitionItem = await _unitOfWork.ConsolidatedRequisitionItemRepository.GetByIdAsync(id);
            if (consolidatedRequisitionItem == null || consolidatedRequisitionItem.IsDeleted)
                throw new Exception("Object not found!");

            if (updateConsolidatedRequisitionItem.Description != null)
                consolidatedRequisitionItem.Description = updateConsolidatedRequisitionItem.Description;
            if (updateConsolidatedRequisitionItem.Quantity != null)
                consolidatedRequisitionItem.Quantity = updateConsolidatedRequisitionItem.Quantity;

            consolidatedRequisitionItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ConsolidatedRequisitionItemRepository.Update(consolidatedRequisitionItem);
            await _unitOfWork.CompleteAsync();
        }
    }
}
