using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class SupplierQuotationItemService : ISupplierQuotationItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierQuotationItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierQuotationItem> CreateSupplierQuotationItemAsync(CreateSupplierQuotationItem createSupplierQuotationItem)
        {
            var supplierQuotationItem = new SupplierQuotationItem
            {
                CreatedAt = DateTime.UtcNow,
                IsOffered = createSupplierQuotationItem.IsOffered,
                LeadTime = createSupplierQuotationItem.LeadTime,
                Notes = createSupplierQuotationItem.Notes,
                OfferedPrice = createSupplierQuotationItem.OfferedPrice,
                OfferedQuantity = createSupplierQuotationItem.OfferedQuantity,
                RequestForQuotationItemId = createSupplierQuotationItem.RequestForQuotationItemId,
                SupplierProductCode = createSupplierQuotationItem.SupplierProductCode,
                SupplierQuotationId = createSupplierQuotationItem.SupplierQuotationId
            };

            await _unitOfWork.SupplierQuotationItemRepository.AddAsync(supplierQuotationItem);
            await _unitOfWork.CompleteAsync();
            return supplierQuotationItem;
        }

        public async Task DeleteSupplierQuotationItemAsync(int id)
        {
            var supplierQuotationItem = await _unitOfWork.SupplierQuotationItemRepository.GetByIdAsync(id);
            if (supplierQuotationItem == null)
                throw new Exception("SupplierQuotationItem not found!");

            supplierQuotationItem.IsDeleted = true;
            supplierQuotationItem.DeletedAt = DateTime.UtcNow;

            _unitOfWork.SupplierQuotationItemRepository.Update(supplierQuotationItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SupplierQuotationItem>> GetAllSupplierQuotationItemAsync()
        {
            var supplierQuotationItem = await _unitOfWork.SupplierQuotationItemRepository.FindManyAsync(u => !u.IsDeleted);
            if (supplierQuotationItem == null)
                throw new Exception("SupplierQuotationItem does not have any object!");

            return supplierQuotationItem;
        }

        public async Task<SupplierQuotationItem> GetSupplierQuotationItemByIdAsync(int id)
        {
            var supplierQuotationItem = await _unitOfWork.SupplierQuotationItemRepository.GetByIdAsync(id);
            if (supplierQuotationItem == null || supplierQuotationItem.IsDeleted)
                throw new Exception("Object not found!");

            return supplierQuotationItem;
        }

        public async Task UpdateSupplierQuotationItemAsync(int id, UpdateSupplierQuotationItem updateSupplierQuotationItem)
        {
            var supplierQuotationItem = await _unitOfWork.SupplierQuotationItemRepository.GetByIdAsync(id);
            if (supplierQuotationItem == null || supplierQuotationItem.IsDeleted)
                throw new Exception("Object not found!");


            if (updateSupplierQuotationItem.SupplierProductCode != null)
                supplierQuotationItem.SupplierProductCode = updateSupplierQuotationItem.SupplierProductCode;
            if (updateSupplierQuotationItem.OfferedQuantity != null)
                supplierQuotationItem.OfferedQuantity = updateSupplierQuotationItem.OfferedQuantity;
            if (updateSupplierQuotationItem.OfferedPrice != null)
                supplierQuotationItem.OfferedPrice = updateSupplierQuotationItem.OfferedPrice;
            if (updateSupplierQuotationItem.Notes != null)
                supplierQuotationItem.Notes = updateSupplierQuotationItem.Notes;
            if (updateSupplierQuotationItem.LeadTime != null)
                supplierQuotationItem.LeadTime = updateSupplierQuotationItem.LeadTime;
            if (updateSupplierQuotationItem.IsOffered != null)
                supplierQuotationItem.IsOffered = updateSupplierQuotationItem.IsOffered;

            supplierQuotationItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.SupplierQuotationItemRepository.Update(supplierQuotationItem);
            await _unitOfWork.CompleteAsync();
        }
    }
}
