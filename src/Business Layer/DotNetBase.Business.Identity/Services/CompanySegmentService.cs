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
    public class CompanySegmentService : ICompanySegmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanySegmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanySegment> CreateCompanySegmentAsync(CreateCompanySegment createCompanySegment)
        {
            var companySegment = new CompanySegment
            {
                CreatedAt = DateTime.Now,
                Description = createCompanySegment.Description,
                SegmentName = createCompanySegment.SegmentName
            };

            await _unitOfWork.CompanySegmentRepository.AddAsync(companySegment);
            await _unitOfWork.CompleteAsync();
            return companySegment;
        }

        public async Task DeleteCompanySegmentAsync(int id)
        {
            var companySegment = await _unitOfWork.CompanySegmentRepository.GetByIdAsync(id);
            if (companySegment == null)
                throw new Exception("Object not found!");

            companySegment.DeletedAt = DateTime.UtcNow;
            companySegment.IsDeleted = true;

            _unitOfWork.CompanySegmentRepository.Update(companySegment);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CompanySegment>> GetAllCompanySegmentAsync()
        {
            var companySegment = await _unitOfWork.CompanySegmentRepository.FindManyAsync(x => !x.IsDeleted);
            if (companySegment == null)
                throw new Exception("Company Segment does not have any object!");

            return companySegment;
        }

        public async Task<CompanySegment> GetCompanySegmentByIdAsync(int id)
        {
            var companySegment = await _unitOfWork.CompanySegmentRepository.GetByIdAsync(id);
            if (companySegment == null)
                throw new Exception("Object not found!");

            return companySegment;
        }

        public async Task UpdateCompanySegmentAsync(int id, UpdateCompanySegment updateCompanySegment)
        {
            var companySegment = await _unitOfWork.CompanySegmentRepository.GetByIdAsync(id);
            if (companySegment == null)
                throw new Exception("Object not found!");

            if (updateCompanySegment.SegmentName != null)
                companySegment.SegmentName = updateCompanySegment.SegmentName;
            if (updateCompanySegment.Description != null)
                companySegment.Description = updateCompanySegment.Description;

            companySegment.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.CompanySegmentRepository.Update(companySegment);
            await _unitOfWork.CompleteAsync();
        }
    }
}
