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
    public interface ICompanyInteractionService
    {
        Task<IEnumerable<CompanyInteraction>> GetAllCompanyInteractionAsync();
        Task<CompanyInteraction> GetCompanyInteractionByIdAsync(int id);
        Task<CompanyInteraction> CreateCompanyInteractionAsync(CreateCompanyInteraction createCompanyInteraction);
        Task UpdateCompanyInteractionAsync(int id, UpdateCompanyInteraction updateCompanyInteraction);
        Task DeleteCompanyInteractionAsync(int id);
    }
}
