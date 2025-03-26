using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class SupplierQuotationService : ISupplierQuotationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierQuotationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SupplierQuotation> CreateSupplierQuotationAsync(CreateSupplierQuotation createSupplierQuotation)
        {
            if (createSupplierQuotation.QuotationNumber == null)
                throw new Exception("QuotationNumber can not be null!");

            var supplierQuotation = new SupplierQuotation
            {
                CreatedAt = DateTime.UtcNow,
                CurrencyId = createSupplierQuotation.CurrencyId,
                DeliveryTerms = createSupplierQuotation.DeliveryTerms,
                ExpirationDate = createSupplierQuotation.ExpirationDate,
                Notes = createSupplierQuotation.Notes,
                PaymentTerms = createSupplierQuotation.PaymentTerms,
                QuotationApprovalStatusId = createSupplierQuotation.QuotationApprovalStatusId,
                QuotationDate = createSupplierQuotation.QuotationDate,
                QuotationNumber = createSupplierQuotation.QuotationNumber,
                QuotationStatusId = createSupplierQuotation.QuotationStatusId,
                RequestForQuotationId = createSupplierQuotation.RequestForQuotationId,
                SupplierCompanyId = createSupplierQuotation.SupplierCompanyId,
                SubmissionDate = createSupplierQuotation.SubmissionDate
            };

            await _unitOfWork.SupplierQuotationRepository.AddAsync(supplierQuotation);
            await _unitOfWork.CompleteAsync();
            return supplierQuotation;
        }

        public async Task DeleteSupplierQuotationAsync(int id)
        {
            var supplierQuotation = await _unitOfWork.SupplierQuotationRepository.GetByIdAsync(id);
            if (supplierQuotation == null)
                throw new Exception("SupplierQuotation not found!");

            supplierQuotation.IsDeleted = true;
            supplierQuotation.DeletedAt = DateTime.UtcNow;

            _unitOfWork.SupplierQuotationRepository.Update(supplierQuotation);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<SupplierQuotation>> GetAllSupplierQuotationAsync()
        {
            var supplierQuotation = await _unitOfWork.SupplierQuotationRepository.FindManyAsync(u => !u.IsDeleted);
            if (supplierQuotation == null)
                throw new Exception("SupplierQuotation does not have any object!");

            return supplierQuotation;
        }

        public async Task<SupplierQuotation> GetSupplierQuotationByIdAsync(int id)
        {
            var supplierQuotation = await _unitOfWork.SupplierQuotationRepository.GetByIdAsync(id);
            if (supplierQuotation == null || supplierQuotation.IsDeleted)
                throw new Exception("Object not found!");

            return supplierQuotation;
        }

        public async Task UpdateSupplierQuotationAsync(int id, UpdateSupplierQuotation updateSupplierQuotation)
        {
            var supplierQuotation = await _unitOfWork.SupplierQuotationRepository.GetByIdAsync(id);
            if (supplierQuotation == null || supplierQuotation.IsDeleted)
                throw new Exception("Object not found!");


            if (updateSupplierQuotation.QuotationDate != null)
                supplierQuotation.QuotationDate = updateSupplierQuotation.QuotationDate;
            if (updateSupplierQuotation.QuotationNumber != null)
                supplierQuotation.QuotationNumber = updateSupplierQuotation.QuotationNumber;
            if (updateSupplierQuotation.ExpirationDate != null)
                supplierQuotation.ExpirationDate = updateSupplierQuotation.ExpirationDate;
            if (updateSupplierQuotation.Notes != null)
                supplierQuotation.Notes = updateSupplierQuotation.Notes;
            if (updateSupplierQuotation.SubmissionDate != null)
                supplierQuotation.SubmissionDate = updateSupplierQuotation.SubmissionDate;
            if (updateSupplierQuotation.DeliveryTerms != null)
                supplierQuotation.DeliveryTerms = updateSupplierQuotation.DeliveryTerms;
            if (updateSupplierQuotation.PaymentTerms != null)
                supplierQuotation.PaymentTerms = updateSupplierQuotation.PaymentTerms;

            supplierQuotation.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.SupplierQuotationRepository.Update(supplierQuotation);
            await _unitOfWork.CompleteAsync();
        }
    }
}
