using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanyAddressService
    {
        Task<IEnumerable<CompanyAddress>> GetAllCompanyAddressAsync();
        Task<CompanyAddress> GetCompanyAddressByIdAsync(int id);
        Task<CompanyAddress> CreateCompanyAddressAsync(CreateCompanyAddress createCompanyAddress);
        Task UpdateCompanyAddressAsync(int id, UpdateCompanyAddress updateCompanyAddress);
        Task DeleteCompanyAddressAsync(int id);
    }
}
