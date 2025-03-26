using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ISupplierQuotationItemService
    {
        Task<IEnumerable<SupplierQuotationItem>> GetAllSupplierQuotationItemAsync();
        Task<SupplierQuotationItem> GetSupplierQuotationItemByIdAsync(int id);
        Task<SupplierQuotationItem> CreateSupplierQuotationItemAsync(CreateSupplierQuotationItem createSupplierQuotationItem);
        Task UpdateSupplierQuotationItemAsync(int id, UpdateSupplierQuotationItem updateSupplierQuotationItem);
        Task DeleteSupplierQuotationItemAsync(int id);
    }
}
