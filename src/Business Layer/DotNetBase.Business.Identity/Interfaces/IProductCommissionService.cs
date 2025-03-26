using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface IProductCommissionService
    {
        Task<IEnumerable<ProductCommission>> GetAllProductCommissionAsync();
        Task<ProductCommission> GetProductCommissionByIdAsync(int id);
        Task<ProductCommission> CreateProductCommissionAsync(CreateProductCommission createProductCommission);
        Task UpdateProductCommissionAsync(int id, UpdateProductCommission updateProductCommission);
    }
}
