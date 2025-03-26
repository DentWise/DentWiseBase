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
    public interface IRequestForQuotationItemService
    {
        Task<IEnumerable<RequestForQuotationItem>> GetAllRequestForQuotationItemAsync();
        Task<RequestForQuotationItem> GetRequestForQuotationItemByIdAsync(int id);
        Task<RequestForQuotationItem> CreateRequestForQuotationItemAsync(CreateRequestForQuotationItem createRequestForQuotationItem);
        Task UpdateRequestForQuotationItemAsync(int id, UpdateRequestForQuotationItem updateRequestForQuotationItem);
        Task DeleteRequestForQuotationItemAsync(int id);
    }
}
