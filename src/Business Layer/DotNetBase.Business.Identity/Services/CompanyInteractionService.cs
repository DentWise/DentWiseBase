using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyInteractionService : ICompanyInteractionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyInteractionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<CompanyInteraction> CreateCompanyInteractionAsync(CreateCompanyInteraction createCompanyInteraction)
        {
            if (createCompanyInteraction.CompanyId == null || createCompanyInteraction.ContactId == null)
                throw new Exception("Company and Contact cannot null!");

            var companyInteraction = new CompanyInteraction
            {
                CompanyId = createCompanyInteraction.CompanyId,
                ContactId = createCompanyInteraction.ContactId,
                UserId = createCompanyInteraction.UserId,
                InteractionType = createCompanyInteraction.InteractionType,
                InteractionDate = DateTime.UtcNow,
                Subject = createCompanyInteraction.Subject,
                Notes = createCompanyInteraction.Notes,
                ContactSentiment = createCompanyInteraction.ContactSentiment,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.CompanyInteractionRepository.AddAsync(companyInteraction);
            await _unitOfWork.CompleteAsync();

            return companyInteraction;
        }

        public async Task DeleteCompanyInteractionAsync(int id)
        {
            var companyInteraction = await _unitOfWork.CompanyInteractionRepository.GetByIdAsync(id);
            if (companyInteraction == null)
                throw new Exception("Object not found!");
            
            companyInteraction.IsDeleted = true;
            companyInteraction.DeletedAt = DateTime.UtcNow;

            _unitOfWork.CompanyInteractionRepository.Update(companyInteraction);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanyInteraction>> GetAllCompanyInteractionAsync()
        {
            var companyInteractions = await _unitOfWork.CompanyInteractionRepository.FindManyAsync(x => !x.IsDeleted);
            if (companyInteractions == null)
                throw new Exception("Company Interaction does not have any object!");

            return companyInteractions;
        }

        public async Task<CompanyInteraction> GetCompanyInteractionByIdAsync(int id)
        {
            var companyInteraction = await _unitOfWork.CompanyInteractionRepository.GetByIdAsync(id);
            if (companyInteraction == null)
                throw new Exception("Object not found!");

            return companyInteraction;
        }

        public async Task UpdateCompanyInteractionAsync(int id, UpdateCompanyInteraction updateCompanyInteraction)
        {
            var companyInteraction = await _unitOfWork.CompanyInteractionRepository.GetByIdAsync(id);
            if (companyInteraction == null)
                throw new Exception("Object not found!");

            if (updateCompanyInteraction.InteractionType != null)
                companyInteraction.InteractionType = updateCompanyInteraction.InteractionType;
            if (updateCompanyInteraction.Notes != null)
                companyInteraction.Notes = updateCompanyInteraction.Notes;
            if (updateCompanyInteraction.Subject != null)
                companyInteraction.Subject = updateCompanyInteraction.Subject;

            companyInteraction.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanyInteractionRepository.Update(companyInteraction);
            await _unitOfWork.CompleteAsync();
        }
    }
}
