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
    public class RequestForQuotationItemService : IRequestForQuotationItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RequestForQuotationItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestForQuotationItem> CreateRequestForQuotationItemAsync(CreateRequestForQuotationItem createRequestForQuotationItem)
        {
            if (createRequestForQuotationItem.RequestForQuotationId == null)
                throw new Exception("RequestForQuotationId can not be null!");

            var requestForQuotationItem = new RequestForQuotationItem
            {
                ConsolidatedRequisitionItemId = createRequestForQuotationItem.RequestForQuotationId,
                CreatedAt = DateTime.UtcNow,
                Description = createRequestForQuotationItem.Description,
                RequestForQuotationId = createRequestForQuotationItem.RequestForQuotationId,
                Quantity = createRequestForQuotationItem.Quantity
            };

            await _unitOfWork.RequestForQuotationItemRepository.AddAsync(requestForQuotationItem);
            await _unitOfWork.CompleteAsync();
            return requestForQuotationItem;
        }

        public async Task DeleteRequestForQuotationItemAsync(int id)
        {
            var requestForQuotationItem = await _unitOfWork.RequestForQuotationItemRepository.GetByIdAsync(id);
            if (requestForQuotationItem == null)
                throw new Exception("RequestForQuotationItem not found!");

            requestForQuotationItem.IsDeleted = true;
            requestForQuotationItem.DeletedAt = DateTime.UtcNow;

            _unitOfWork.RequestForQuotationItemRepository.Update(requestForQuotationItem);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<RequestForQuotationItem>> GetAllRequestForQuotationItemAsync()
        {
            var requestForQuotationItem = await _unitOfWork.RequestForQuotationItemRepository.FindManyAsync(u => !u.IsDeleted);
            return requestForQuotationItem;
        }

        public async Task<RequestForQuotationItem> GetRequestForQuotationItemByIdAsync(int id)
        {
            var requestForQuotationItem = await _unitOfWork.RequestForQuotationItemRepository.GetByIdAsync(id);
            if (requestForQuotationItem == null || requestForQuotationItem.IsDeleted)
                throw new Exception("RequestForQuotationItem does not have any object!");

            return requestForQuotationItem;
        }

        public async Task UpdateRequestForQuotationItemAsync(int id, UpdateRequestForQuotationItem updateRequestForQuotationItem)
        {
            var requestForQuotationItem = await _unitOfWork.ConsolidatedRequisitionItemRepository.GetByIdAsync(id);
            if (requestForQuotationItem == null || requestForQuotationItem.IsDeleted)
                throw new Exception("Object not found!");

            if (updateRequestForQuotationItem.Description != null)
                requestForQuotationItem.Description = updateRequestForQuotationItem.Description;
            if (updateRequestForQuotationItem.Quantity != null)
                requestForQuotationItem.Quantity = updateRequestForQuotationItem.Quantity;

            requestForQuotationItem.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.ConsolidatedRequisitionItemRepository.Update(requestForQuotationItem);
            await _unitOfWork.CompleteAsync();
        }
    }
}
