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
    public class RequisitionItemService : IRequisitionItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequisitionItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequisitionItem> CreateRequisitionItemAsync(CreateRequisitionItem createRequisitionItem)
        {
            if (createRequisitionItem.PurchaseRequisitionId == null)
                throw new Exception("PurchaseRequisitionId can not be null!");

            var requisitionItem = new RequisitionItem
            {
                CreatedAt = DateTime.UtcNow,
                Description = createRequisitionItem.Description,
                ProductId = createRequisitionItem.ProductId,
                PurchaseRequisitionId = createRequisitionItem.PurchaseRequisitionId,
                Quantity = createRequisitionItem.Quantity,
            };

            await _unitOfWork.RequisitionItemRepository.AddAsync(requisitionItem);
            await _unitOfWork.CompleteAsync();
            return requisitionItem;
        }

        public async Task DeleteRequisitionItemAsync(int id)
        {
            var requisitionItem = await _unitOfWork.RequisitionItemRepository.GetByIdAsync(id);
            if (requisitionItem == null)
                throw new Exception("RequisitionItem not found!");

            requisitionItem.IsDeleted = true;
            requisitionItem.DeletedAt = DateTime.UtcNow;

            _unitOfWork.RequisitionItemRepository.Update(requisitionItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<RequisitionItem>> GetAllRequisitionItemAsync()
        {
            var requisitionItem = await _unitOfWork.RequisitionItemRepository.FindManyAsync(u => !u.IsDeleted);
            if (requisitionItem == null)
                throw new Exception("RequisitionItem does not have any object!");

            return requisitionItem;
        }

        public async Task<RequisitionItem> GetRequisitionItemByIdAsync(int id)
        {
            var requisitionItem = await _unitOfWork.RequisitionItemRepository.GetByIdAsync(id);
            if (requisitionItem == null || requisitionItem.IsDeleted)
                throw new Exception("Object not found!");

            return requisitionItem;
        }

        public async Task UpdateRequisitionItemAsync(int id, UpdateRequisitionItem updateRequisitionItem)
        {
            var requisitionItem = await _unitOfWork.RequisitionItemRepository.GetByIdAsync(id);
            if (requisitionItem == null || requisitionItem.IsDeleted)
                throw new Exception("Object not found!");


            if (updateRequisitionItem.Description != null)
                requisitionItem.Description = updateRequisitionItem.Description;
            if (updateRequisitionItem.Quantity != null)
                requisitionItem.Quantity = updateRequisitionItem.Quantity;

            requisitionItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.RequisitionItemRepository.Update(requisitionItem);
            await _unitOfWork.CompleteAsync();
        }
    }
}
