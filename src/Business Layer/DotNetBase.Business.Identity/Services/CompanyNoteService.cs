using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.EFCore.Entities;
using DotNetBase.EFCore.UnitOfWork;
using DotNetBase.Entities.Dto.RequestModel;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Business.Identity.Services
{
    public class CompanyNoteService : ICompanyNoteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyNoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyNote> CreateCompanyNoteAsync(CreateCompanyNote createCompanyNote)
        {
            if (createCompanyNote.CompanyId == null)
                throw new Exception("Company area can not null!");

            var companyNote = new CompanyNote
            {
                CompanyId = createCompanyNote.CompanyId,
                CreatedAt = DateTime.UtcNow,
                NoteText = createCompanyNote.NoteText,
                CreatedByUserId = createCompanyNote.CreatedByUserId
            };

            await _unitOfWork.CompanyNoteRepository.AddAsync(companyNote);
            await _unitOfWork.CompleteAsync();
            return companyNote;
        }

        public async Task DeleteCompanyNoteAsync(int id)
        {
            var companyNote = await _unitOfWork.CompanyNoteRepository.GetByIdAsync(id);
            if (companyNote == null)
                throw new Exception("Object not found!");

            companyNote.DeletedAt = DateTime.UtcNow;
            companyNote.IsDeleted = true;

            _unitOfWork.CompanyNoteRepository.Update(companyNote);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanyNote>> GetAllCompanyNoteAsync()
        {
            var companyNote = await _unitOfWork.CompanyNoteRepository.FindManyAsync(x => !x.IsDeleted);
            if (companyNote == null)
                throw new Exception("Company Note does not have any object!");

            return companyNote;
        }

        public async Task<CompanyNote> GetCompanyNoteByIdAsync(int id)
        {
            var companyNote = await _unitOfWork.CompanyNoteRepository.GetByIdAsync(id);
            if (companyNote == null)
                throw new Exception("Object not found!");

            return companyNote;
        }

        public async Task UpdateCompanyNoteAsync(int id, UpdateCompanyNote updateCompanyNote)
        {
            var companyNote = await _unitOfWork.CompanyNoteRepository.GetByIdAsync(id);
            if (companyNote == null)
                throw new Exception("Object not found!");

            if (updateCompanyNote.NoteText != null)
                companyNote.NoteText = updateCompanyNote.NoteText;

            companyNote.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanyNoteRepository.Update(companyNote);
            await _unitOfWork.CompleteAsync();
        }
    }
}
