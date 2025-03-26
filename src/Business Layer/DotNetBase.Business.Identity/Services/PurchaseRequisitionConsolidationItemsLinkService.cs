using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class PurchaseRequisitionConsolidationItemsLinkService : IPurchaseRequisitionConsolidationItemsLinkService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseRequisitionConsolidationItemsLinkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseRequisitionConsolidationItemsLink> CreatePurchaseRequisitionConsolidationItemsLinkAsync(CreatePurchaseRequisitionConsolidationItemsLink createPurchaseRequisitionConsolidationItemsLink)
        {
            if (createPurchaseRequisitionConsolidationItemsLink.RequisitionItemId == null)
                throw new Exception("RequisitionItemId can not be null");

            var purchaseRequisitionConsolidationItemsLink = new PurchaseRequisitionConsolidationItemsLink
            {
                ConsolidatedRequisitionItemId = createPurchaseRequisitionConsolidationItemsLink.RequisitionItemId,
                CreatedAt = DateTime.UtcNow,
                Quantity = createPurchaseRequisitionConsolidationItemsLink.Quantity,
                RequisitionItemId = createPurchaseRequisitionConsolidationItemsLink.RequisitionItemId
            };

            await _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.AddAsync(purchaseRequisitionConsolidationItemsLink);
            await _unitOfWork.CompleteAsync();
            return purchaseRequisitionConsolidationItemsLink;
        }

        public async Task DeletePurchaseRequisitionConsolidationItemsLinkAsync(int id)
        {
            var purchaseRequisitionConsolidationItemsLink = await _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.GetByIdAsync(id);
            if (purchaseRequisitionConsolidationItemsLink == null)
                throw new Exception("PurchaseRequisitionConsolidationItemsLink not found!");

            purchaseRequisitionConsolidationItemsLink.IsDeleted = true;
            purchaseRequisitionConsolidationItemsLink.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.Update(purchaseRequisitionConsolidationItemsLink);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PurchaseRequisitionConsolidationItemsLink>> GetAllPurchaseRequisitionConsolidationItemsLinkAsync()
        {
            var purchaseRequisitionConsolidationItemsLink = await _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.FindManyAsync(u => !u.IsDeleted);
            if (purchaseRequisitionConsolidationItemsLink == null)
                throw new Exception("PurchaseRequisitionConsolidationItemsLink does not have any object!");

            return purchaseRequisitionConsolidationItemsLink;
        }

        public async Task<PurchaseRequisitionConsolidationItemsLink> GetPurchaseRequisitionConsolidationItemsLinkByIdAsync(int id)
        {
            var purchaseRequisitionConsolidationItemsLink = await _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.GetByIdAsync(id);
            if (purchaseRequisitionConsolidationItemsLink == null || purchaseRequisitionConsolidationItemsLink.IsDeleted)
                throw new Exception("Object not found!");

            return purchaseRequisitionConsolidationItemsLink;
        }

        public async Task UpdatePurchaseRequisitionConsolidationItemsLinkAsync(int id, UpdatePurchaseRequisitionConsolidationItemsLink updatePurchaseRequisitionConsolidationItemsLink)
        {
            var purchaseRequisitionConsolidationItemsLink = await _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.GetByIdAsync(id);
            if (purchaseRequisitionConsolidationItemsLink == null || purchaseRequisitionConsolidationItemsLink.IsDeleted)
                throw new Exception("Object not found!");


            if (updatePurchaseRequisitionConsolidationItemsLink.RequisitionItemId != null)
                purchaseRequisitionConsolidationItemsLink.RequisitionItemId = updatePurchaseRequisitionConsolidationItemsLink.RequisitionItemId;
            if (updatePurchaseRequisitionConsolidationItemsLink.ConsolidatedRequisitionItemId != null)
                purchaseRequisitionConsolidationItemsLink.ConsolidatedRequisitionItemId = updatePurchaseRequisitionConsolidationItemsLink.ConsolidatedRequisitionItemId;
            if (updatePurchaseRequisitionConsolidationItemsLink.Quantity != null)
                purchaseRequisitionConsolidationItemsLink.Quantity = updatePurchaseRequisitionConsolidationItemsLink.Quantity;

            purchaseRequisitionConsolidationItemsLink.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.PurchaseRequisitionConsolidationItemsLinkRepository.Update(purchaseRequisitionConsolidationItemsLink);
            await _unitOfWork.CompleteAsync();
        }
    }
}
