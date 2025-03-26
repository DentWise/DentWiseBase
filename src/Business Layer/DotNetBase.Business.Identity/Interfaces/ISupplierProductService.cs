using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ISupplierProductService
    {
        Task<IEnumerable<SupplierProduct>> GetAllSupplierProductAsync();
        Task<SupplierProduct> GetSupplierProductByIdAsync(int id);
        Task<SupplierProduct> CreateSupplierProductAsync(CreateSupplierProduct createSupplierProduct);
        Task UpdateSupplierProductAsync(int id, UpdateSupplierProduct updateSupplierProduct);
        Task DeleteSupplierProductAsync(int id);
    }
}
