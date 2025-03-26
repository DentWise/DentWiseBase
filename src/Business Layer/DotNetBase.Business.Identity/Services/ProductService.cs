using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProductAsync(CreateProduct createProduct)
        {
            if (createProduct.ProductName == null)
                throw new Exception("ProductName can not be null!");

            var product = new Product
            {
                ProductName = createProduct.ProductName,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                ProductBrandId = createProduct.ProductBrandId,
                ProductCategoryId = createProduct.ProductCategoryId,
                ProductCode = createProduct.ProductCode,
                SalePrice = createProduct.SalePrice,
                PurchasePrice = createProduct.PurchasePrice,
                ProductDescription = createProduct.ProductDescription,
                ProductUnitId = createProduct.ProductUnitId
            };

            await _unitOfWork.ProductRepository.AddAsync(product);

            var productImage = new ProductImage
            {
                CreatedAt = DateTime.UtcNow,
                Description = createProduct.ProductImage.Description,
                IsDefault = true,
                ImagePath = createProduct.ProductImage.ImagePath,
                ProductId = product.Id
            };

            await _unitOfWork.ProductImageRepository.AddAsync(productImage);
            await _unitOfWork.CompleteAsync();
            return product;
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null)
                throw new Exception("Product not found!");

            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow;

            var productImage = await _unitOfWork.ProductImageRepository.FindManyAsync(x => x.ProductId == id);

            foreach (var image in productImage)
            {
                image.IsDeleted = true;
                image.DeletedAt = DateTime.UtcNow;
                _unitOfWork.ProductImageRepository.Update(image);
            }

            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            var product = await _unitOfWork.ProductRepository.FindManyAsync(u => !u.IsDeleted);
            if (product == null)
                throw new Exception("Product does not have any object!");

            return product;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null || product.IsDeleted)
                throw new Exception("Object not found!!");

            return product;
        }

        public async Task UpdateProductAsync(int id, UpdateProduct updateProduct)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product == null || product.IsDeleted)
                throw new Exception("Object not found!!");


            if (updateProduct.ProductDescription != null)
                product.ProductDescription = updateProduct.ProductDescription;
            if (updateProduct.ProductCode != null)
                product.ProductCode = updateProduct.ProductCode;
            if (updateProduct.ProductName != null)
                product.ProductName = updateProduct.ProductName;
            if (updateProduct.PurchasePrice != null)
                product.PurchasePrice = updateProduct.PurchasePrice;
            if (updateProduct.ProductUnitId != null)
                product.ProductUnitId = updateProduct.ProductUnitId;
            if (updateProduct.SalePrice != null)
                product.SalePrice = updateProduct.SalePrice;

            product.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.CompleteAsync();
        }
    }
}
