using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanyNoteService
    {
        Task<IEnumerable<CompanyNote>> GetAllCompanyNoteAsync();
        Task<CompanyNote> GetCompanyNoteByIdAsync(int id);
        Task<CompanyNote> CreateCompanyNoteAsync(CreateCompanyNote createCompanyNote);
        Task UpdateCompanyNoteAsync(int id, UpdateCompanyNote updateCompanyNote);
        Task DeleteCompanyNoteAsync(int id);
    }
}
