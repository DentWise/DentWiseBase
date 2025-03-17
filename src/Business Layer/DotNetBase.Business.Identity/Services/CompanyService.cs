//using DotNetBase.Business.Identity.Interfaces;
//using DotNetBase.EFCore.UnitOfWork;
//using DotNetBase.Entities.Dto.RequestModels;
//using DotNetBase.Entities.Identity;
//using DotNetBase.Entities.Organization;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Task = System.Threading.Tasks.Task;

//namespace DotNetBase.Business.Identity.Services
//{
//    public class CompanyService : ICompanyService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CompanyService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<Company> CreateCompanyAsync(CompanyCreateDto createCompany)
//        {
//            var companyExist = await _unitOfWork.CompanyRepository.FindOneAsync(x => x.TaxNumber == createCompany.TaxNumber);
//            if (companyExist != null)
//                throw new Exception("Tax number already exist!");

//            var company = new Company
//            {
//                TaxNumber = createCompany.TaxNumber,
//                CreatedAt = DateTime.UtcNow,
//                Name = createCompany.Name,
//                Status = createCompany.Status,
//                TaxOffice = createCompany.TaxOffice,
//                Type = createCompany.Type
//            };
//            await _unitOfWork.CompanyRepository.AddAsync(company);

//            var companyAddress = new CompanyAddress
//            {
//                Address = createCompany.Address,
//                City = createCompany.City,
//                Country = createCompany.Country,
//                CreatedAt = DateTime.UtcNow,
//                CompanyId = company.Id,
//                IsDefault = true,
//                PostalCode = createCompany.PostalCode
//            };
//            await _unitOfWork.CompanyAddressRepository.AddAsync(companyAddress);

//            await _unitOfWork.CompleteAsync();

//            return company;
//        }

//        public async Task DeleteCompanyAsync(int id)
//        {
//            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
//            if (company == null)
//                throw new Exception("Company not found!");

//            company.IsDeleted = true;
//            company.DeletedAt = DateTime.UtcNow;

//            _unitOfWork.CompanyRepository.Update(company);
//            await _unitOfWork.CompleteAsync();
//        }

//        public async Task<IEnumerable<Company>> GetAllCompanyAsync()
//        {
//            var company = await _unitOfWork.CompanyRepository.FindManyAsync(u => !u.IsDeleted);
//            return company;
//        }

//        public async Task<Company> GetCompanyByIdAsync(int id)
//        {
//            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
//            if (company == null || company.IsDeleted)
//                throw new Exception("Object not found!");

//            return company;
//        }

//        public async Task UpdateCompanyAsync(int id, CompanyUpdateDto updateCompany)
//        {
//            var company = await _unitOfWork.CompanyRepository.GetByIdAsync(id);
//            if (company == null || company.IsDeleted)
//                throw new Exception("Object not found!");

//            if (!string.IsNullOrEmpty(updateCompany.TaxNumber) && updateCompany.TaxNumber != updateCompany.TaxNumber)
//            {
//                var existingCompany = await _unitOfWork.CompanyRepository.FindOneAsync(u => u.TaxNumber == updateCompany.TaxNumber && u.Id != id && !u.IsDeleted);
//                if (existingCompany != null)
//                    throw new InvalidOperationException("A company with this tax number already exists.");
//            }

//            if (updateCompany.Status != null)
//                company.Status = updateCompany.Status.Value;
//            if (updateCompany.Type != null)
//                company.Type = updateCompany.Type.Value;
//            if (updateCompany.TaxNumber != null)
//                company.TaxNumber = updateCompany.TaxNumber;
//            if (updateCompany.Name != null)
//                company.Name = updateCompany.Name;
//            if (updateCompany.TaxOffice != null)
//                company.TaxOffice = updateCompany.TaxOffice;

//            _unitOfWork.CompanyRepository.Update(company);
//            await _unitOfWork.CompleteAsync();
//        }
//    }
//}
