using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Company> CreateCompanyAsync(CreateCompany createCompany)
        {
            var companyExist = await _unitOfWork.CompanyRepository.FindOneAsync(x => x.TaxNumber == createCompany.TaxNumber);
            if (companyExist != null)
                throw new Exception("Tax number already exist!");

            var company = new Company
            {
                TaxNumber = createCompany.TaxNumber,
                CreatedAt = DateTime.UtcNow,
                TaxOffice = createCompany.TaxOffice,
                CompanyName = createCompany.CompanyName,
                CompanyTypeId = createCompany.CompanyTypeId,
                Phone = createCompany.Phone,
                Email = createCompany.Email,
                Website = createCompany.Website,
                LogoUrl = createCompany.LogoUrl,
                CompanyStatus = createCompany.CompanyStatus
            };
            await _unitOfWork.CompanyRepository.AddAsync(company);

            var companyAddress = new CompanyAddress
            {
                AddressLine = createCompany.AddressLine,
                City = createCompany.City,
                Country = createCompany.Country,
                CreatedAt = DateTime.UtcNow,
                CompanyId = company.Id,
                IsDefault = true,
                PostalCode = createCompany.PostalCode
            };
            await _unitOfWork.CompanyAddressRepository.AddAsync(companyAddress);
            
            var companyStatusHistory = new CompanyStatusHistory
            {
                CompanyId = company.Id,
                CreatedAt = DateTime.UtcNow,
                StatusDate = DateTime.UtcNow,
                Status = createCompany.CompanyStatus,
                Notes = createCompany.StatusNote
            };

            await _unitOfWork.CompanyStatusHistoryRepository.AddAsync(companyStatusHistory);

            await _unitOfWork.CompleteAsync();

            return company;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            if (company == null)
                throw new Exception("Company not found!");

            company.IsDeleted = true;
            company.DeletedAt = DateTime.UtcNow;

            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Company>> GetAllCompanyAsync()
        {
            var company = await _unitOfWork.CompanyRepository.FindManyAsync(u => !u.IsDeleted);
            if (company == null)
                throw new Exception("Company does not have any object!");
            return company;
        }

        public async Task<Company> GetCompanyByIdAsync(int id)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            if (company == null || company.IsDeleted)
                throw new Exception("Object not found!");

            return company;
        }

        public async Task UpdateCompanyAsync(int id, UpdateCompany updateCompany)
        {
            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
            if (company == null || company.IsDeleted)
                throw new Exception("Object not found!");

            if (!string.IsNullOrEmpty(updateCompany.TaxNumber) && updateCompany.TaxNumber != updateCompany.TaxNumber)
            {
                var existingCompany = await _unitOfWork.CompanyRepository.FindOneAsync(u => u.TaxNumber == updateCompany.TaxNumber && u.Id != id && !u.IsDeleted);
                if (existingCompany != null)
                    throw new InvalidOperationException("A company with this tax number already exists.");
            }

            if (updateCompany.TaxOffice != null)
                company.TaxOffice = updateCompany.TaxOffice;
            if (updateCompany.TaxNumber != null)
                company.TaxNumber = updateCompany.TaxNumber;
            if (updateCompany.CompanyName != null)
                company.CompanyName = updateCompany.CompanyName;
            if (updateCompany.Phone != null)
                company.Phone = updateCompany.Phone;
            if (updateCompany.Email != null)
                company.Email = updateCompany.Email;
            if (updateCompany.Website != null)
                company.Website = updateCompany.Website;
            if (updateCompany.LogoUrl != null)
                company.LogoUrl = updateCompany.LogoUrl;
            if (updateCompany.CompanyStatus != null)
            {
                company.CompanyStatus = updateCompany.CompanyStatus;

                var companyStatusHistory = new CompanyStatusHistory
                {
                    CompanyId = id,
                    CreatedAt = DateTime.UtcNow,
                    Status = updateCompany.CompanyStatus,
                    StatusDate = DateTime.UtcNow,
                    Notes = updateCompany.CompanyStatusNote
                };
                await _unitOfWork.CompanyStatusHistoryRepository.AddAsync(companyStatusHistory);
            }

            company.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanyRepository.Update(company);
            await _unitOfWork.CompleteAsync();
        }
    }
}
