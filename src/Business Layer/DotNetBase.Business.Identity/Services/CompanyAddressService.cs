using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModels;
using DotNetBase.Entities.Organization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyAddressService : ICompanyAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyAddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<CompanyAddress> CreateCompanyAddressAsync(CompanyAddressCreateDto createCompanyAddress)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task DeleteCompanyAddressAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompanyAddress>> GetAllCompanyAddressAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CompanyAddress> GetCompanyAddressByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateCompanyAddressAsync(int id, CompanyAddressUpdateDto updateCompanyAddress)
        {
            throw new NotImplementedException();
        }
    }
}
