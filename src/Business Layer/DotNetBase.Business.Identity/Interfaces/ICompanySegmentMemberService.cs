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
    public interface ICompanySegmentMemberService
    {
        Task<IEnumerable<CompanySegmentMember>> GetAllCompanySegmentMemberAsync();
        Task<CompanySegmentMember> GetCompanySegmentMemberByIdAsync(int id);
        Task<CompanySegmentMember> CreateCompanySegmentMemberAsync(CreateCompanySegmentMember createCompanySegment);
        Task UpdateCompanySegmentMemberAsync(int id, UpdateCompanySegmentMember updateCompanySegment);
        Task DeleteCompanySegmentMemberAsync(int id);
    }
}
