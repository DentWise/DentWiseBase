using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class ProductCommissionService : IProductCommissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCommissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductCommission> CreateProductCommissionAsync(CreateProductCommission createProductCommission)
        {
            var productCommission = new ProductCommission
            {
                CreatedAt = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                ProductId = createProductCommission.ProductId,
                Rate = createProductCommission.Rate,
                StartDate = DateTime.UtcNow
            };

            await _unitOfWork.ProductCommissionRepository.AddAsync(productCommission);
            await _unitOfWork.CompleteAsync();
            return productCommission;
        }

        public async Task<IEnumerable<ProductCommission>> GetAllProductCommissionAsync()
        {
            var productCommission = await _unitOfWork.ProductCommissionRepository.GetAllAsync();
            if (productCommission == null)
                throw new Exception("ProductCommission does not have any object!");

            return productCommission;
        }

        public async Task<ProductCommission> GetProductCommissionByIdAsync(int id)
        {
            var productCommission = await _unitOfWork.ProductCommissionRepository.GetByIdAsync(id);
            if (productCommission == null)
                throw new Exception("Object not found!!");

            return productCommission;
        }

        public async Task UpdateProductCommissionAsync(int id, UpdateProductCommission updateProductCommission)
        {
            var productCommission = await _unitOfWork.ProductCommissionRepository.GetByIdAsync(id);
            if (productCommission == null)
                throw new Exception("Object not found!!");


            if (updateProductCommission.IsActive != null)
                productCommission.IsActive = updateProductCommission.IsActive;
            if (updateProductCommission.Rate != null)
                productCommission.Rate = updateProductCommission.Rate;

            productCommission.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ProductCommissionRepository.Update(productCommission);
            await _unitOfWork.CompleteAsync();
        }
    }
}
