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
    public class PurchaseOrderService : IPurchaseOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrder> CreatePurchaseOrderAsync(CreatePurchaseOrder createPurchaseOrder)
        {
            if (createPurchaseOrder.PurchaseOrderNumber == null)
                throw new Exception("PurchaseOrderNumber can not be null!");

            var purchaseOrder = new PurchaseOrder
            {
                CreatedAt = DateTime.UtcNow,
                CurrencyId = createPurchaseOrder.CurrencyId,
                DeliveryTerms = createPurchaseOrder.DeliveryTerms,
                Description = createPurchaseOrder.Description,
                ExpectedDeliveryDate = createPurchaseOrder.ExpectedDeliveryDate,
                OrderAmount = createPurchaseOrder.OrderAmount,
                PaymentTerms = createPurchaseOrder.PaymentTerms,
                PurchaseOrderDate = createPurchaseOrder.PurchaseOrderDate,
                PurchaseOrderNumber = createPurchaseOrder.PurchaseOrderNumber,
                PurchaseOrderStatusId = createPurchaseOrder.PurchaseOrderStatusId,
                RequestForQuotationId = createPurchaseOrder.RequestForQuotationId,
                SupplierCompanyId = createPurchaseOrder.SupplierCompanyId,
                SupplierQuotationId = createPurchaseOrder.SupplierQuotationId,
            };

            await _unitOfWork.PurchaseOrderRepository.AddAsync(purchaseOrder);
            await _unitOfWork.CompleteAsync();
            return purchaseOrder;
        }

        public async Task DeletePurchaseOrderAsync(int id)
        {
            var purchaseOrder = await _unitOfWork.PurchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder == null)
                throw new Exception("PurchaseOrder not found!");

            purchaseOrder.IsDeleted = true;
            purchaseOrder.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PurchaseOrderRepository.Update(purchaseOrder);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetAllPurchaseOrderAsync()
        {
            var purchaseOrder = await _unitOfWork.PurchaseOrderRepository.FindManyAsync(u => !u.IsDeleted);
            if (purchaseOrder == null)
                throw new Exception("PurchaseOrder does not have any object!");

            return purchaseOrder;
        }

        public async Task<PurchaseOrder> GetPurchaseOrderByIdAsync(int id)
        {
            var purchaseOrder = await _unitOfWork.PurchaseOrderRepository.GetByIdAsync(id);
            if (purchaseOrder == null || purchaseOrder.IsDeleted)
                throw new Exception("Object not found!!");

            return purchaseOrder;
        }
    }
}
