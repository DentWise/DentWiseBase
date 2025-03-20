using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanyTypeService
    {
        Task<IEnumerable<CompanyType>> GetAllCompanyTypeAsync();
        Task<CompanyType> GetCompanyTypeByIdAsync(int id);
        Task<CompanyType> CreateCompanyTypeAsync(CreateCompanyType createCompanyType);
        Task UpdateCompanyTypeAsync(int id, UpdateCompanyType updateCompanyType);
        Task DeleteCompanyTypeAsync(int id);
    }
}
