using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyAddressService : ICompanyAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyAddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyAddress> CreateCompanyAddressAsync(CreateCompanyAddress createCompanyAddress)
        {
            if (createCompanyAddress.CompanyId == null)
                throw new Exception("Company Id cannot null!");

            var companyAddress = new CompanyAddress
            {
                CompanyId = createCompanyAddress.CompanyId,
                AddressLine = createCompanyAddress.AddressLine,
                City = createCompanyAddress.City,
                PostalCode = createCompanyAddress.PostalCode,
                Country = createCompanyAddress.Country,
                CreatedAt = DateTime.UtcNow,
                IsDefault = createCompanyAddress.IsDefault
            };

            await _unitOfWork.CompanyAddressRepository.AddAsync(companyAddress);
            await _unitOfWork.CompleteAsync();

            return companyAddress;
        }

        public async Task DeleteCompanyAddressAsync(int id)
        {
            var companyAddress = await _unitOfWork.CompanyAddressRepository.GetByIdAsync(id);
            if (companyAddress == null)
                throw new Exception("Object not found!");

            companyAddress.DeletedAt = DateTime.UtcNow;
            companyAddress.IsDeleted = true;

            _unitOfWork.CompanyAddressRepository.Update(companyAddress);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanyAddress>> GetAllCompanyAddressAsync()
        {
            var companyAddresses = await _unitOfWork.CompanyAddressRepository.FindManyAsync(x => !x.IsDeleted);
            if (companyAddresses == null)
                throw new Exception("Company adresses does not have any object!");

            return companyAddresses;
        }

        public async Task<CompanyAddress> GetCompanyAddressByIdAsync(int id)
        {
            var companyAddress = await _unitOfWork.CompanyAddressRepository.GetByIdAsync(id);
            if (companyAddress == null)
                throw new Exception("Object not found!");

            return companyAddress;
        }

        public async Task UpdateCompanyAddressAsync(int id, UpdateCompanyAddress updateCompanyAddress)
        {
            var companyAddress = await _unitOfWork.CompanyAddressRepository.GetByIdAsync(id);
            if(companyAddress == null)
                throw new Exception("Object not found!");

            if (updateCompanyAddress.AddressLine != null)
                companyAddress.AddressLine = updateCompanyAddress.AddressLine;
            if (updateCompanyAddress.PostalCode != null)
                companyAddress.PostalCode = updateCompanyAddress.PostalCode;
            if (updateCompanyAddress.City != null)
                companyAddress.City = updateCompanyAddress.City;
            if (companyAddress.Country != null)
                companyAddress.Country = updateCompanyAddress.Country;

            companyAddress.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanyAddressRepository.Update(companyAddress);
            await _unitOfWork.CompleteAsync();
        }
    }
}
