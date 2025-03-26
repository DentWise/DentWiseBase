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
    public class PurchaseOrderItemService : IPurchaseOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrderItem> CreatePurchaseOrderItemAsync(CreatePurchaseOrderItem createPurchaseOrderItem)
        {
            if (createPurchaseOrderItem.PurchaseOrderId == null)
                throw new Exception("PurchaseOrder can not be null!");

            var purchaseOrderItem = new PurchaseOrderItem
            {
                PurchaseOrderId = createPurchaseOrderItem.PurchaseOrderId,
                CreatedAt = DateTime.UtcNow,
                Description = createPurchaseOrderItem.Description,
                LineAmount = createPurchaseOrderItem.LineAmount,
                OrderedQuantity = createPurchaseOrderItem.OrderedQuantity,
                ProductId = createPurchaseOrderItem.ProductId,
                SupplierQuotationItemId = createPurchaseOrderItem.SupplierQuotationItemId,
                UnitPrice = createPurchaseOrderItem.UnitPrice
            };
            await _unitOfWork.PurchaseOrderItemRepository.AddAsync(purchaseOrderItem);
            await _unitOfWork.CompleteAsync();
            return purchaseOrderItem;
        }

        public async Task DeletePurchaseOrderItemAsync(int id)
        {
            var purchaseOrderItem = await _unitOfWork.PurchaseOrderItemRepository.GetByIdAsync(id);
            if (purchaseOrderItem == null)
                throw new Exception("Product not found!");

            purchaseOrderItem.IsDeleted = true;
            purchaseOrderItem.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PurchaseOrderItemRepository.Update(purchaseOrderItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PurchaseOrderItem>> GetAllPurchaseOrderItemAsync()
        {
            var purchaseOrderItem = await _unitOfWork.PurchaseOrderItemRepository.FindManyAsync(u => !u.IsDeleted);
            if (purchaseOrderItem == null)
                throw new Exception("PurchaseOrderItem does not have any object!");

            return purchaseOrderItem;
        }

        public async Task<PurchaseOrderItem> GetPurchaseOrderItemByIdAsync(int id)
        {
            var purchaseOrderItem = await _unitOfWork.PurchaseOrderItemRepository.GetByIdAsync(id);
            if (purchaseOrderItem == null || purchaseOrderItem.IsDeleted)
                throw new Exception("Object not found!!");

            return purchaseOrderItem;
        }

        public async Task UpdatePurchaseOrderItemAsync(int id, UpdatePurchaseOrderItem updatePurchaseOrderItem)
        {
            var purchaseOrderItem = await _unitOfWork.PurchaseOrderItemRepository.GetByIdAsync(id);
            if (purchaseOrderItem == null || purchaseOrderItem.IsDeleted)
                throw new Exception("Object not found!!");


            if (updatePurchaseOrderItem.UnitPrice != null)
                purchaseOrderItem.UnitPrice = updatePurchaseOrderItem.UnitPrice;
            if (updatePurchaseOrderItem.LineAmount != null)
                purchaseOrderItem.LineAmount = updatePurchaseOrderItem.LineAmount;
            if (updatePurchaseOrderItem.OrderedQuantity != null)
                purchaseOrderItem.OrderedQuantity = updatePurchaseOrderItem.OrderedQuantity;
            if (updatePurchaseOrderItem.Description != null)
                purchaseOrderItem.Description = updatePurchaseOrderItem.Description;

            purchaseOrderItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.PurchaseOrderItemRepository.Update(purchaseOrderItem);
            await _unitOfWork.CompleteAsync();
        }
    }
}
