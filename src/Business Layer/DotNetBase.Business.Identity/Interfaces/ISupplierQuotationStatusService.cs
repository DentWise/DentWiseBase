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
    public interface ISupplierQuotationStatusService
    {
        Task<IEnumerable<SupplierQuotationStatus>> GetAllSupplierQuotationStatusAsync();
        Task<SupplierQuotationStatus> GetSupplierQuotationStatusByIdAsync(int id);
        Task<SupplierQuotationStatus> CreateSupplierQuotationStatusAsync(CreateSupplierQuotationStatus createSupplierQuotationStatus);
        Task UpdateSupplierQuotationStatusAsync(int id, UpdateSupplierQuotationStatus updateSupplierQuotationStatus);
        Task DeleteSupplierQuotationStatusAsync(int id);
    }
}
