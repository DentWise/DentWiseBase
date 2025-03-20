using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class PaymentStatusService : IPaymentStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaymentStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentStatus> CreatePaymentStatusAsync(CreatePaymentStatus createPaymentStatus)
        {
            var paymentStatus = new PaymentStatus
            {
                CreatedAt = DateTime.UtcNow,
                Description = createPaymentStatus.Description,
                IsDefault = createPaymentStatus.IsDefault,
                StatusName = createPaymentStatus.StatusName
            };
            await _unitOfWork.PaymentStatusRepository.AddAsync(paymentStatus);
            await _unitOfWork.CompleteAsync();
            return paymentStatus;
        }

        public async Task DeletePaymentStatusAsync(int id)
        {
            var paymentStatus = await _unitOfWork.PaymentStatusRepository.GetByIdAsync(id);
            if (paymentStatus == null)
                throw new Exception("PaymentStatus not found!");

            paymentStatus.IsDeleted = true;
            paymentStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.PaymentStatusRepository.Update(paymentStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<PaymentStatus>> GetAllPaymentStatusAsync()
        {
            var paymentStatus = await _unitOfWork.PaymentStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (paymentStatus == null)
                throw new Exception("PaymentStatus does not have any object!");

            return paymentStatus;
        }

        public async Task<PaymentStatus> GetPaymentStatusByIdAsync(int id)
        {
            var paymentStatus = await _unitOfWork.PaymentStatusRepository.GetByIdAsync(id);
            if (paymentStatus == null || paymentStatus.IsDeleted)
                throw new Exception("Object not found!!");

            return paymentStatus;
        }

        public async Task UpdatePaymentStatusAsync(int id, UpdatePaymentStatus updatePaymentStatus)
        {
            var paymentStatus = await _unitOfWork.PaymentStatusRepository.GetByIdAsync(id);
            if (paymentStatus == null || paymentStatus.IsDeleted)
                throw new Exception("Object not found!!");


            if (updatePaymentStatus.IsDefault != null)
                paymentStatus.IsDefault = updatePaymentStatus.IsDefault;
            if (updatePaymentStatus.StatusName != null)
                paymentStatus.StatusName = updatePaymentStatus.StatusName;
            if (updatePaymentStatus.Description != null)
                paymentStatus.Description = updatePaymentStatus.Description;

            paymentStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.PaymentStatusRepository.Update(paymentStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
