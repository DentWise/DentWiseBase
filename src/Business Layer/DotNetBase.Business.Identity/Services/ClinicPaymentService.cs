using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class ClinicPaymentService : IClinicPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClinicPaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClinicPayment> CreateClinicPaymentAsync(CreateClinicPayment createClinicPayment)
        {
            if (createClinicPayment.ClinicCompanyId == null)
                throw new Exception("CompanyId can not null!");

            if (createClinicPayment.PurchaseRequestConsolidationId == null)
                throw new Exception("ConsolidationId can not null!");

            var clinicPayment = new ClinicPayment
            {
                ClinicCompanyId = createClinicPayment.ClinicCompanyId,
                ReferenceNumber = createClinicPayment.ReferenceNumber,
                PurchaseRequestConsolidationId = createClinicPayment.CurrencyId,
                CurrencyId = createClinicPayment.CurrencyId,
                CreatedAt = DateTime.UtcNow,
                Notes = createClinicPayment.Notes,
                PaymentAmount = createClinicPayment.PaymentAmount,
                PaymentDate = createClinicPayment.PaymentDate,
                PaymentMethod = createClinicPayment.PaymentMethod,
                PrePaymentStatusId = createClinicPayment.PrePaymentStatusId
            };
            await _unitOfWork.ClinicPaymentRepository.AddAsync(clinicPayment);
            await _unitOfWork.CompleteAsync();

            return clinicPayment;
        }

        public async Task DeleteClinicPaymentAsync(int id)
        {
            var clinicPayment = await _unitOfWork.ClinicPaymentRepository.GetByIdAsync(id);
            if (clinicPayment == null)
                throw new Exception("Object not found!");

            clinicPayment.DeletedAt = DateTime.UtcNow;
            clinicPayment.IsDeleted = true;

            _unitOfWork.ClinicPaymentRepository.Update(clinicPayment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ClinicPayment>> GetAllClinicPaymentAsync()
        {
            var clinics = await _unitOfWork.ClinicPaymentRepository.FindManyAsync(x => !x.IsDeleted);
            if (clinics == null)
                throw new Exception("Clinic payment does not have any object!");

            return clinics;
        }

        public async Task<ClinicPayment> GetClinicPaymentByIdAsync(int id)
        {
            var clinicPayment = await _unitOfWork.ClinicPaymentRepository.GetByIdAsync(id);
            if (clinicPayment == null)
                throw new Exception("Object not found!");

            return clinicPayment;
        }

        public async Task UpdateClinicPaymentAsync(int id, UpdateClinicPayment updateClinicPayment)
        {
            var clinicPayment = await _unitOfWork.ClinicPaymentRepository.GetByIdAsync(id);
            if (clinicPayment == null)
                throw new Exception("Object not found!");

            if (updateClinicPayment.CurrencyId != null)
                clinicPayment.CurrencyId = updateClinicPayment.CurrencyId.Value;
            if (updateClinicPayment.Notes != null)
                clinicPayment.Notes = updateClinicPayment.Notes;
            if (updateClinicPayment.PaymentMethod != null)
                clinicPayment.PaymentMethod = updateClinicPayment.PaymentMethod;
            if (updateClinicPayment.PrePaymentStatusId != null)
                clinicPayment.PrePaymentStatusId = updateClinicPayment.PrePaymentStatusId;
            if (updateClinicPayment.PaymentAmount != null)
                clinicPayment.PaymentAmount = updateClinicPayment.PaymentAmount.Value;
            if (updateClinicPayment.ReferenceNumber != null)
                clinicPayment.ReferenceNumber = updateClinicPayment.ReferenceNumber;
            if (updateClinicPayment.PaymentDate != null)
                clinicPayment.PaymentDate = updateClinicPayment.PaymentDate.Value;

            clinicPayment.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ClinicPaymentRepository.Update(clinicPayment);
            await _unitOfWork.CompleteAsync();
        }
    }
}
