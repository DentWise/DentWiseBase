using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanyStatusService
    {
        Task<IEnumerable<CompanyStatus>> GetAllCompanyStatusAsync();
        Task<CompanyStatus> GetCompanyStatusByIdAsync(int id);
        Task<CompanyStatus> CreateCompanyStatusAsync(CreateCompanyStatus createCompanyStatus);
        Task UpdateCompanyStatusAsync(int id, UpdateCompanyStatus updateCompanyStatus);
        Task DeleteCompanyStatusAsync(int id);
    }
}
