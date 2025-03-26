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
    public class QuotationApprovalStatusService : IQuotationApprovalStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuotationApprovalStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<QuotationApprovalStatus> CreateQuotationApprovalStatusAsync(CreateQuotationApprovalStatus createQuotationApprovalStatus)
        {
            if (createQuotationApprovalStatus.StatusName == null)
                throw new Exception("StatusName can not be null!");

            var quotationApprovalStatus = new QuotationApprovalStatus
            {
                StatusName = createQuotationApprovalStatus.StatusName,
                CreatedAt = DateTime.UtcNow,
                Description = createQuotationApprovalStatus.Description,
                IsDefault = createQuotationApprovalStatus.IsDefault
            };

            await _unitOfWork.QuotationApprovalStatusRepository.AddAsync(quotationApprovalStatus);
            await _unitOfWork.CompleteAsync();
            return quotationApprovalStatus;
        }

        public async Task DeleteQuotationApprovalStatusAsync(int id)
        {
            var quotationApprovalStatus = await _unitOfWork.QuotationApprovalStatusRepository.GetByIdAsync(id);
            if (quotationApprovalStatus == null)
                throw new Exception("QuotationApprovalStatus not found!");

            quotationApprovalStatus.IsDeleted = true;
            quotationApprovalStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.QuotationApprovalStatusRepository.Update(quotationApprovalStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<QuotationApprovalStatus>> GetAllQuotationApprovalStatusAsync()
        {
            var quotationApprovalStatus = await _unitOfWork.QuotationApprovalStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (quotationApprovalStatus == null)
                throw new Exception("QuotationApprovalStatus does not have any object!");

            return quotationApprovalStatus;
        }

        public async Task<QuotationApprovalStatus> GetQuotationApprovalStatusByIdAsync(int id)
        {
            var quotationApprovalStatus = await _unitOfWork.QuotationApprovalStatusRepository.GetByIdAsync(id);
            if (quotationApprovalStatus == null || quotationApprovalStatus.IsDeleted)
                throw new Exception("Object not found!");

            return quotationApprovalStatus;
        }

        public async Task UpdateQuotationApprovalStatusAsync(int id, UpdateQuotationApprovalStatus updateQuotationApprovalStatus)
        {
            var quotationApprovalStatus = await _unitOfWork.QuotationApprovalStatusRepository.GetByIdAsync(id);
            if (quotationApprovalStatus == null || quotationApprovalStatus.IsDeleted)
                throw new Exception("Object not found!");


            if (updateQuotationApprovalStatus.StatusName != null)
                quotationApprovalStatus.StatusName = updateQuotationApprovalStatus.StatusName;
            if (updateQuotationApprovalStatus.IsDefault != null)
                quotationApprovalStatus.IsDefault = updateQuotationApprovalStatus.IsDefault;
            if (updateQuotationApprovalStatus.Description != null)
                quotationApprovalStatus.Description = updateQuotationApprovalStatus.Description;

            quotationApprovalStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.QuotationApprovalStatusRepository.Update(quotationApprovalStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}