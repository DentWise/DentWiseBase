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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductCategory> CreateProductCategoryAsync(CreateProductCategory createProductCategory)
        {
            if (createProductCategory.CategoryName == null)
                throw new Exception("CategoryName can not be null!");

            var productCategory = new ProductCategory
            {
                CategoryName = createProductCategory.CategoryName,
                CreatedAt = DateTime.UtcNow,
                Description = createProductCategory.Description,
                ParentCategoryId = createProductCategory.ParentCategoryId
            };

            await _unitOfWork.ProductCategoryRepository.AddAsync(productCategory);
            await _unitOfWork.CompleteAsync();

            return productCategory;
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProductCategoryAsync()
        {
            var productCategory = await _unitOfWork.ProductCategoryRepository.GetAllAsync();
            if (productCategory == null)
                throw new Exception("ProductCategory does not have any object!");

            return productCategory;
        }

        public async Task<ProductCategory> GetProducCategoryByIdAsync(int id)
        {
            var productCategory = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(id);
            if (productCategory == null)
                throw new Exception("Object not found!!");

            return productCategory;
        }

        public async Task UpdateProductCategoryAsync(int id, UpdateProductCategory updateProductCategory)
        {
            var productCategory = await _unitOfWork.ProductCategoryRepository.GetByIdAsync(id);
            if (productCategory == null)
                throw new Exception("Object not found!!");


            if (updateProductCategory.CategoryName != null)
                productCategory.CategoryName = updateProductCategory.CategoryName;
            if (updateProductCategory.Description != null)
                productCategory.Description = updateProductCategory.Description;

            productCategory.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ProductCategoryRepository.Update(productCategory);
            await _unitOfWork.CompleteAsync();
        }
    }
}
