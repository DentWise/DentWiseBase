using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ISupplierQuotationService
    {
        Task<IEnumerable<SupplierQuotation>> GetAllSupplierQuotationAsync();
        Task<SupplierQuotation> GetSupplierQuotationByIdAsync(int id);
        Task<SupplierQuotation> CreateSupplierQuotationAsync(CreateSupplierQuotation createSupplierQuotation);
        Task UpdateSupplierQuotationAsync(int id, UpdateSupplierQuotation updateSupplierQuotation);
        Task DeleteSupplierQuotationAsync(int id);
    }
}
