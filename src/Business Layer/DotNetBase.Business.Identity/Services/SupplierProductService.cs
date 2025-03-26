using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class SupplierProductService : ISupplierProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierProduct> CreateSupplierProductAsync(CreateSupplierProduct createSupplierProduct)
        {
            if (createSupplierProduct.ProductId == null)
                throw new Exception("ProductId can not be null!");

            var supplierProduct = new SupplierProduct
            {
                ProductId = createSupplierProduct.ProductId,
                CreatedAt = DateTime.UtcNow,
                CurrencyId = createSupplierProduct.CurrencyId,
                DiscountRates = createSupplierProduct.DiscountRates,
                LeadTime = createSupplierProduct.LeadTime,
                Moq = createSupplierProduct.Moq,
                Notes = createSupplierProduct.Notes,
                SupplierCompanyId = createSupplierProduct.SupplierCompanyId,
                SupplierProductCode = createSupplierProduct.SupplierProductCode,
                SupplierPrice = createSupplierProduct.SupplierPrice
            };

            await _unitOfWork.SupplierProductRepository.AddAsync(supplierProduct);
            await _unitOfWork.CompleteAsync();
            return supplierProduct;
        }

        public async Task DeleteSupplierProductAsync(int id)
        {
            var supplierProduct = await _unitOfWork.SupplierProductRepository.GetByIdAsync(id);
            if (supplierProduct == null)
                throw new Exception("SupplierProduct not found!");

            supplierProduct.IsDeleted = true;
            supplierProduct.DeletedAt = DateTime.UtcNow;

            _unitOfWork.SupplierProductRepository.Update(supplierProduct);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SupplierProduct>> GetAllSupplierProductAsync()
        {
            var supplierProduct = await _unitOfWork.SupplierProductRepository.FindManyAsync(u => !u.IsDeleted);
            if (supplierProduct == null)
                throw new Exception("SupplierProduct does not have any object!");

            return supplierProduct;
        }

        public async Task<SupplierProduct> GetSupplierProductByIdAsync(int id)
        {
            var supplierProduct = await _unitOfWork.SupplierProductRepository.GetByIdAsync(id);
            if (supplierProduct == null || supplierProduct.IsDeleted)
                throw new Exception("Object not found!");

            return supplierProduct;
        }

        public async Task UpdateSupplierProductAsync(int id, UpdateSupplierProduct updateSupplierProduct)
        {
            var supplierProduct = await _unitOfWork.SupplierProductRepository.GetByIdAsync(id);
            if (supplierProduct == null || supplierProduct.IsDeleted)
                throw new Exception("Object not found!");


            if (updateSupplierProduct.Moq != null)
                supplierProduct.Moq = updateSupplierProduct.Moq;
            if (updateSupplierProduct.SupplierProductCode != null)
                supplierProduct.SupplierProductCode = updateSupplierProduct.SupplierProductCode;
            if (updateSupplierProduct.DiscountRates != null)
                supplierProduct.DiscountRates = updateSupplierProduct.DiscountRates;
            if (updateSupplierProduct.Notes != null)
                supplierProduct.Notes = updateSupplierProduct.Notes;
            if (updateSupplierProduct.LeadTime != null)
                supplierProduct.LeadTime = updateSupplierProduct.LeadTime;
            if (updateSupplierProduct.SupplierPrice != null)
                supplierProduct.SupplierPrice = updateSupplierProduct.SupplierPrice;

            supplierProduct.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.SupplierProductRepository.Update(supplierProduct);
            await _unitOfWork.CompleteAsync();
        }
    }
}
