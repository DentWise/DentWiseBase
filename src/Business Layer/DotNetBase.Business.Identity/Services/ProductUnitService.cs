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
    public class ProductUnitService : IProductUnitService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductUnitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductUnit> CreateProductUnitAsync(CreateProductUnit createProductUnit)
        {
            var productUnit = new ProductUnit
            {
                CreatedAt = DateTime.UtcNow,
                Description = createProductUnit.Description,
                IsDefault = createProductUnit.IsDefault,
                UnitName = createProductUnit.UnitName
            };

            await _unitOfWork.ProductUnitRepository.AddAsync(productUnit);
            await _unitOfWork.CompleteAsync();
            return productUnit;
        }

        public async Task DeleteProductUnitAsync(int id)
        {
            var productUnit = await _unitOfWork.ProductUnitRepository.GetByIdAsync(id);
            if (productUnit == null)
                throw new Exception("Product not found!");

            productUnit.IsDeleted = true;
            productUnit.DeletedAt = DateTime.UtcNow;

            _unitOfWork.ProductUnitRepository.Update(productUnit);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ProductUnit>> GetAllProductUnitAsync()
        {
            var productUnit = await _unitOfWork.ProductUnitRepository.FindManyAsync(u => !u.IsDeleted);
            if (productUnit == null)
                throw new Exception("ProductUnit does not have any object!");

            return productUnit;
        }

        public async Task<ProductUnit> GetProductUnitByIdAsync(int id)
        {
            var productUnit = await _unitOfWork.ProductUnitRepository.GetByIdAsync(id);
            if (productUnit == null || productUnit.IsDeleted)
                throw new Exception("Object not found!!");

            return productUnit;
        }

        public async Task UpdateProductUnitAsync(int id, UpdateProductUnit updateProductUnit)
        {
            var productUnit = await _unitOfWork.ProductUnitRepository.GetByIdAsync(id);
            if (productUnit == null || productUnit.IsDeleted)
                throw new Exception("Object not found!!");


            if (updateProductUnit.Description != null)
                productUnit.Description = updateProductUnit.Description;
            if (updateProductUnit.UnitName != null)
                productUnit.UnitName = updateProductUnit.UnitName;

                productUnit.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ProductUnitRepository.Update(productUnit);
            await _unitOfWork.CompleteAsync();
        }
    }
}
