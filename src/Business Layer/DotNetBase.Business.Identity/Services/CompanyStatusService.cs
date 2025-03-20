using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyStatusService : ICompanyStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyStatus> CreateCompanyStatusAsync(CreateCompanyStatus createCompanyStatus)
        {
            var companyStatus = new CompanyStatus
            {
                CreatedAt = DateTime.UtcNow,
                Name = createCompanyStatus.Name,
                StatusLeg = createCompanyStatus.StatusLeg
            };

            await _unitOfWork.CompanyStatusRepository.AddAsync(companyStatus);
            await _unitOfWork.CompleteAsync();

            return companyStatus;
        }

        public async Task DeleteCompanyStatusAsync(int id)
        {
            var companyStatus = await _unitOfWork.CompanyStatusRepository.GetByIdAsync(id);
            if (companyStatus == null)
                throw new Exception("Object not found!");

            companyStatus.DeletedAt = DateTime.UtcNow;
            companyStatus.IsDeleted = true;

            _unitOfWork.CompanyStatusRepository.Update(companyStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanyStatus>> GetAllCompanyStatusAsync()
        {
            var companyStatus = await _unitOfWork.CompanyStatusRepository.FindManyAsync(x => !x.IsDeleted);
            if (companyStatus == null)
                throw new Exception("Company Note does not have any object!");

            return companyStatus;
        }

        public async Task<CompanyStatus> GetCompanyStatusByIdAsync(int id)
        {
            var companyStatus = await _unitOfWork.CompanyStatusRepository.GetByIdAsync(id);
            if (companyStatus == null)
                throw new Exception("Object not found!");

            return companyStatus;
        }

        public async Task UpdateCompanyStatusAsync(int id, UpdateCompanyStatus updateCompanyStatus)
        {
            var companyStatus = await _unitOfWork.CompanyStatusRepository.GetByIdAsync(id);
            if (companyStatus == null)
                throw new Exception("Object not found!");

            if (updateCompanyStatus.Name != null)
                companyStatus.Name = updateCompanyStatus.Name;

            companyStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanyStatusRepository.Update(companyStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
