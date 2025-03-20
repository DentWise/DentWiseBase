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
    public class CompanySegmentMemberService : ICompanySegmentMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanySegmentMemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanySegmentMember> CreateCompanySegmentMemberAsync(CreateCompanySegmentMember createCompanySegment)
        {
            if (createCompanySegment.CompanyId == null || createCompanySegment.CompanySegmentId == null)
                throw new Exception("CompanyId or CompanySegmentId can not be null!");

            var companySegmentMember = new CompanySegmentMember
            {
                CompanyId = createCompanySegment.CompanyId,
                CompanySegmentId = createCompanySegment.CompanySegmentId,
                CreatedAt = DateTime.UtcNow,
                AddedAt = DateTime.UtcNow,
                UserId = createCompanySegment.UserId
            };

            await _unitOfWork.CompanySegmentMemberRepository.AddAsync(companySegmentMember);
            await _unitOfWork.CompleteAsync();

            return companySegmentMember;
        }

        public async Task DeleteCompanySegmentMemberAsync(int id)
        {
            var companySegmentMember = await _unitOfWork.CompanySegmentMemberRepository.GetByIdAsync(id);
            if (companySegmentMember == null)
                throw new Exception("Object not found!");

            companySegmentMember.DeletedAt = DateTime.UtcNow;
            companySegmentMember.IsDeleted = true;

            _unitOfWork.CompanySegmentMemberRepository.Update(companySegmentMember);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanySegmentMember>> GetAllCompanySegmentMemberAsync()
        {
            var companySegmentMember = await _unitOfWork.CompanySegmentMemberRepository.FindManyAsync(x => !x.IsDeleted);
            if (companySegmentMember == null)
                throw new Exception("CompanySegnentMember does not have any object!");

            return companySegmentMember;
        }

        public async Task<CompanySegmentMember> GetCompanySegmentMemberByIdAsync(int id)
        {
            var companySegmentMember = await _unitOfWork.CompanySegmentMemberRepository.GetByIdAsync(id);
            if (companySegmentMember == null)
                throw new Exception("Object not found!");

            return companySegmentMember;
        }

        public async Task UpdateCompanySegmentMemberAsync(int id, UpdateCompanySegmentMember updateCompanySegment)
        {
            var companySegmentMember = await _unitOfWork.CompanySegmentMemberRepository.GetByIdAsync(id);
            if (companySegmentMember == null)
                throw new Exception("Object not found!");

            if (updateCompanySegment.CompanySegmentId != null)
                companySegmentMember.CompanySegmentId = updateCompanySegment.CompanySegmentId;
            if (updateCompanySegment.CompanyId != null)
                companySegmentMember.CompanyId = updateCompanySegment.CompanyId;

            companySegmentMember.UpdatedAt = DateTime.Now;
            _unitOfWork.CompanySegmentMemberRepository.Update(companySegmentMember);
            await _unitOfWork.CompleteAsync();
        }
    }
}
