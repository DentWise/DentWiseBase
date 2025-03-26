using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class RequestForQuotationService : IRequestForQuotationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestForQuotationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestForQuotation> CreateRequestForQuotationAsync(CreateRequestForQuotation createRequestForQuotation)
        {
            if (createRequestForQuotation.Rfqnumber == null)
                throw new Exception("RfqNumber can not be null!");

            var requestForQuotation = new RequestForQuotation
            {
                CreatedAt = DateTime.UtcNow,
                Description = createRequestForQuotation.Description,
                PurchaseRequestConsolidationId = createRequestForQuotation.PurchaseRequestConsolidationId,
                Rfqnumber = createRequestForQuotation.Rfqnumber,
                Rfqdate = createRequestForQuotation.Rfqdate,
                ResponseDueDate = createRequestForQuotation.ResponseDueDate,
                RfqstatusId = createRequestForQuotation.RfqstatusId,
                SentDate = createRequestForQuotation.SentDate,
                SupplierCompanyId = createRequestForQuotation.SupplierCompanyId
            };

            await _unitOfWork.RequestForQuotationRepository.AddAsync(requestForQuotation);
            await _unitOfWork.CompleteAsync();
            return requestForQuotation;
        }

        public async Task DeleteRequestForQuotationAsync(int id)
        {
            var requestForQuotation = await _unitOfWork.RequestForQuotationRepository.GetByIdAsync(id);
            if (requestForQuotation == null)
                throw new Exception("RequestForQuotation not found!");

            requestForQuotation.IsDeleted = true;
            requestForQuotation.DeletedAt = DateTime.UtcNow;

            _unitOfWork.RequestForQuotationRepository.Update(requestForQuotation);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<RequestForQuotation>> GetAllRequestForQuotationAsync()
        {
            var requestForQuotation = await _unitOfWork.RequestForQuotationRepository.FindManyAsync(u => !u.IsDeleted);
            if (requestForQuotation == null)
                throw new Exception("RequestForQuotation does not have any object!");

            return requestForQuotation;
        }

        public async Task<RequestForQuotation> GetRequestForQuotationByIdAsync(int id)
        {
            var requestForQuotation = await _unitOfWork.RequestForQuotationRepository.GetByIdAsync(id);
            if (requestForQuotation == null || requestForQuotation.IsDeleted)
                throw new Exception("Object not found!");

            return requestForQuotation;
        }

        public async Task UpdateRequestForQuotationAsync(int id, UpdateRequestForQuotation updateRequestForQuotation)
        {
            var requestForQuotation = await _unitOfWork.RequestForQuotationRepository.GetByIdAsync(id);
            if (requestForQuotation == null || requestForQuotation.IsDeleted)
                throw new Exception("Object not found!");


            if (updateRequestForQuotation.ResponseDueDate != null)
                requestForQuotation.ResponseDueDate = updateRequestForQuotation.ResponseDueDate;
            if (updateRequestForQuotation.SentDate != null)
                requestForQuotation.SentDate = updateRequestForQuotation.SentDate;
            if (updateRequestForQuotation.Description != null)
                requestForQuotation.Description = updateRequestForQuotation.Description;

            requestForQuotation.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.RequestForQuotationRepository.Update(requestForQuotation);
            await _unitOfWork.CompleteAsync();
        }
    }
}
