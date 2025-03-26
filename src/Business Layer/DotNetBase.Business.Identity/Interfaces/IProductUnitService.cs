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
    public interface IProductUnitService
    {
        Task<IEnumerable<ProductUnit>> GetAllProductUnitAsync();
        Task<ProductUnit> GetProductUnitByIdAsync(int id);
        Task<ProductUnit> CreateProductUnitAsync(CreateProductUnit createProductUnit);
        Task UpdateProductUnitAsync(int id, UpdateProductUnit updateProductUnit);
        Task DeleteProductUnitAsync(int id);
    }
}
