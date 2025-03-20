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
    public class InteractionTypeService : IInteractionTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public InteractionTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InteractionType> CreateInteractionTypeAsync(CreateInteractionType createInteractionType)
        {
            var interactionType = new InteractionType
            {
                CreatedAt = DateTime.Now,
                Name = createInteractionType.Name
            };

            await _unitOfWork.InteractionTypeRepository.AddAsync(interactionType);
            await _unitOfWork.CompleteAsync();

            return interactionType;
        }

        public async Task DeleteInteractionTypeAsync(int id)
        {
            var interactionType = await _unitOfWork.InteractionTypeRepository.GetByIdAsync(id);
            if (interactionType == null)
                throw new Exception("InteractionType not found!");

            interactionType.IsDeleted = true;
            interactionType.DeletedAt = DateTime.UtcNow;

            _unitOfWork.InteractionTypeRepository.Update(interactionType);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<InteractionType>> GetAllInteractionTypeAsync()
        {
            var interactionType = await _unitOfWork.InteractionTypeRepository.FindManyAsync(u => !u.IsDeleted);
            if (interactionType == null)
                throw new Exception("InteractionType does not have any object!");

            return interactionType;
        }

        public async Task<InteractionType> GetInteractionTypeByIdAsync(int id)
        {
            var interactionType = await _unitOfWork.InteractionTypeRepository.GetByIdAsync(id);
            if (interactionType == null || interactionType.IsDeleted)
                throw new Exception("Object not found!!");

            return interactionType;
        }

        public async Task UpdateInteractionTypeAsync(int id, UpdateInteractionType updateInteractionType)
        {
            var interactionType = await _unitOfWork.InteractionTypeRepository.GetByIdAsync(id);
            if (interactionType == null || interactionType.IsDeleted)
                throw new Exception("Object not found!!");

            interactionType.UpdatedAt = DateTime.UtcNow;
            interactionType.Name = interactionType.Name;

            _unitOfWork.InteractionTypeRepository.Update(interactionType);
            await _unitOfWork.CompleteAsync();
        }
    }
}
