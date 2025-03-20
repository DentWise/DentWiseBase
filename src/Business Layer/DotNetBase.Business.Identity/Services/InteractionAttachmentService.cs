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
    public class InteractionAttachmentService : IInteractionAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InteractionAttachmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InteractionAttachment> CreateInteractionAttachmentAsync(CreateInteractionAttachment createInteractionAttachment)
        {
            if (createInteractionAttachment.CompanyInteractionId == null)
                throw new Exception("CompanyInteractionId cannot be null!");

            var interactionAttachment = new InteractionAttachment
            {
                CompanyInteractionId = createInteractionAttachment.CompanyInteractionId,
                CreatedAt = DateTime.UtcNow,
                FileName = createInteractionAttachment.FileName,
                FilePath = createInteractionAttachment.FilePath,
                FileSize = createInteractionAttachment.FileSize,
                UploadDate = createInteractionAttachment.UploadDate,
                UserId = createInteractionAttachment.UserId
            };

            await _unitOfWork.InteractionAttachmentRepository.AddAsync(interactionAttachment);
            await _unitOfWork.CompleteAsync();
            return interactionAttachment;
        }

        public async Task DeleteInteractionAttachmentAsync(int id)
        {
            var interactionAttachment = await _unitOfWork.InteractionAttachmentRepository.GetByIdAsync(id);
            if (interactionAttachment == null)
                throw new Exception("InteractionAttachment not found!");

            interactionAttachment.IsDeleted = true;
            interactionAttachment.DeletedAt = DateTime.UtcNow;

            _unitOfWork.InteractionAttachmentRepository.Update(interactionAttachment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<InteractionAttachment>> GetAllInteractionAttachmentAsync()
        {
            var interactionAttachment = await _unitOfWork.InteractionAttachmentRepository.FindManyAsync(u => !u.IsDeleted);
            if (interactionAttachment == null)
                throw new Exception("InteractionAttachment does not have any object!");

            return interactionAttachment;
        }

        public async Task<InteractionAttachment> GetInteractionAttachmentByIdAsync(int id)
        {
            var interactionAttachment = await _unitOfWork.InteractionAttachmentRepository.GetByIdAsync(id);
            if (interactionAttachment == null || interactionAttachment.IsDeleted)
                throw new Exception("Object not found!!");

            return interactionAttachment;
        }
    }
}
