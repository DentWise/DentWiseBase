using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompanyAsync();
        Task<Company> GetCompanyByIdAsync(int id);
        Task<Company> CreateCompanyAsync(CreateCompany createCompany);
        Task UpdateCompanyAsync(int id, UpdateCompany updateCompany);
        Task DeleteCompanyAsync(int id);
    }
}
