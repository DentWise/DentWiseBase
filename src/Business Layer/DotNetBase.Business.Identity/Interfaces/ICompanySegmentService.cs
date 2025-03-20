using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Interfaces
{
    public interface ICompanySegmentService
    {
        Task<IEnumerable<CompanySegment>> GetAllCompanySegmentAsync();
        Task<CompanySegment> GetCompanySegmentByIdAsync(int id);
        Task<CompanySegment> CreateCompanySegmentAsync(CreateCompanySegment createCompanySegment);
        Task UpdateCompanySegmentAsync(int id, UpdateCompanySegment updateCompanySegment);
        Task DeleteCompanySegmentAsync(int id);
    }
}
