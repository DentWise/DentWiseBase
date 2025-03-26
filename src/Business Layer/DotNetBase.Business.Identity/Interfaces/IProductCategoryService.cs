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
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategoryAsync();
        Task<ProductCategory> GetProducCategoryByIdAsync(int id);
        Task<ProductCategory> CreateProductCategoryAsync(CreateProductCategory createProductCategory);
        Task UpdateProductCategoryAsync(int id, UpdateProductCategory updateProductCategory);
    }
}
