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
    public class RequestForQuotationStatusService : IRequestForQuotationStatusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestForQuotationStatusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestForQuotationStatus> CreateRequestForQuotationStatusAsync(CreateRequestForQuotationStatus createRequestForQuotationStatus)
        {
            if (createRequestForQuotationStatus.StatusName == null)
                throw new Exception("StatusName can not be null!");

            var requestForQuotationStatus = new RequestForQuotationStatus
            {
                CreatedAt = DateTime.UtcNow,
                Description = createRequestForQuotationStatus.Description,
                IsDefault = createRequestForQuotationStatus.IsDefault,
                StatusName = createRequestForQuotationStatus.StatusName
            };

            await _unitOfWork.RequestForQuotationStatusRepository.AddAsync(requestForQuotationStatus);
            await _unitOfWork.CompleteAsync();
            return requestForQuotationStatus;
        }

        public async Task DeleteRequestForQuotationStatusAsync(int id)
        {
            var requestForQuotationStatus = await _unitOfWork.RequestForQuotationStatusRepository.GetByIdAsync(id);
            if (requestForQuotationStatus == null)
                throw new Exception("RequestForQuotationStatus not found!");

            requestForQuotationStatus.IsDeleted = true;
            requestForQuotationStatus.DeletedAt = DateTime.UtcNow;

            _unitOfWork.RequestForQuotationStatusRepository.Update(requestForQuotationStatus);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<RequestForQuotationStatus>> GetAllRequestForQuotationStatusAsync()
        {
            var requestForQuotationStatus = await _unitOfWork.RequestForQuotationStatusRepository.FindManyAsync(u => !u.IsDeleted);
            if (requestForQuotationStatus == null)
                throw new Exception("RequestForQuotationStatus does not have any object!");

            return requestForQuotationStatus;
        }

        public async Task<RequestForQuotationStatus> GetRequestForQuotationStatusByIdAsync(int id)
        {
            var requestForQuotationStatus = await _unitOfWork.RequestForQuotationStatusRepository.GetByIdAsync(id);
            if (requestForQuotationStatus == null || requestForQuotationStatus.IsDeleted)
                throw new Exception("Object not found!");

            return requestForQuotationStatus;
        }

        public async Task UpdateRequestForQuotationStatusAsync(int id, UpdateRequestForQuotationStatus updateRequestForQuotationStatus)
        {
            var requestForQuotationStatus = await _unitOfWork.RequestForQuotationStatusRepository.GetByIdAsync(id);
            if (requestForQuotationStatus == null || requestForQuotationStatus.IsDeleted)
                throw new Exception("Object not found!");


            if (updateRequestForQuotationStatus.IsDefault != null)
                requestForQuotationStatus.IsDefault = updateRequestForQuotationStatus.IsDefault;
            if (updateRequestForQuotationStatus.StatusName != null)
                requestForQuotationStatus.StatusName = updateRequestForQuotationStatus.StatusName;
            if (updateRequestForQuotationStatus.Description != null)
                requestForQuotationStatus.Description = updateRequestForQuotationStatus.Description;

            requestForQuotationStatus.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.RequestForQuotationStatusRepository.Update(requestForQuotationStatus);
            await _unitOfWork.CompleteAsync();
        }
    }
}
