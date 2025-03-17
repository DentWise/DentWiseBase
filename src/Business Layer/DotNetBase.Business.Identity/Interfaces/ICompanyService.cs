using DotNetBase.Entities.Dto.RequestModels;
using DotNetBase.Entities.Identity;
using DotNetBase.Entities.Organization;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanyAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(CompanyCreateDto createCompany);
        Task UpdateCompanyAsync(int id, CompanyUpdateDto updateCompany);
        Task DeleteCompanyAsync(int id);
    }
}
