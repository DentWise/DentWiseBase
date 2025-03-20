using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyTypeService : ICompanyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyType> CreateCompanyTypeAsync(CreateCompanyType createCompanyType)
        {
            var companyType = new CompanyType
            {
                CreatedAt = DateTime.UtcNow,
                TypeName = createCompanyType.TypeName
            };

            await _unitOfWork.CompanyTypeRepository.AddAsync(companyType);
            await _unitOfWork.CompleteAsync();

            return companyType;
        }

        public async Task DeleteCompanyTypeAsync(int id)
        {
            var companyType = await _unitOfWork.CompanyTypeRepository.GetByIdAsync(id);
            if (companyType == null)
                throw new Exception("CompanyType not found!");

            companyType.IsDeleted = true;
            companyType.DeletedAt = DateTime.UtcNow;

            _unitOfWork.CompanyTypeRepository.Update(companyType);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanyType>> GetAllCompanyTypeAsync()
        {
            var companyType = await _unitOfWork.CompanyTypeRepository.FindManyAsync(u => !u.IsDeleted);
            return companyType;
        }

        public async Task<CompanyType> GetCompanyTypeByIdAsync(int id)
        {
            var companyType = await _unitOfWork.CompanyTypeRepository.GetByIdAsync(id);
            if (companyType == null || companyType.IsDeleted)
                throw new Exception("Object not found!");

            return companyType;
        }

        public async Task UpdateCompanyTypeAsync(int id, UpdateCompanyType updateCompanyType)
        {
            var companyType = await _unitOfWork.CompanyTypeRepository.GetByIdAsync(id);
            if (companyType == null || companyType.IsDeleted)
                throw new Exception("Object not found!");

            if (updateCompanyType.TypeName != null)
                companyType.TypeName = updateCompanyType.TypeName;

            companyType.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanyTypeRepository.Update(companyType);
            await _unitOfWork.CompleteAsync();
        }
    }
}
