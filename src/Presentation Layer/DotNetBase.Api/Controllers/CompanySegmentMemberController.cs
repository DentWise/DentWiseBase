using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class CompanySegmentMemberController(CompanySegmentMemberService companySegmentMemberService) : Controller
    {
        [HttpPost("CreateCompanySegmentMember")]
        public async Task<IActionResult> CreateCompanySegmentMemberAsync([FromBody] CreateCompanySegmentMember createCompanySegmentMember)
        {
            try
            {
                var result = await companySegmentMemberService.CreateCompanySegmentMemberAsync(createCompanySegmentMember);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCompanySegmentMember")]
        public async Task DeleteCompanySegmentMemberAsync(int id)
        {
            await companySegmentMemberService.DeleteCompanySegmentMemberAsync(id);
        }

        [HttpGet("GetAllCompanySegmentMember")]
        public async Task<IActionResult> GetAllCompanySegmentMemberAsync()
        {
            try
            {
                var result = await companySegmentMemberService.GetAllCompanySegmentMemberAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanySegmentMemberById")]
        public async Task<IActionResult> GetCompanySegmentMemberByIdAsync(int id)
        {
            try
            {
                var result = await companySegmentMemberService.GetCompanySegmentMemberByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCompanySegmentMember")]
        public async Task UpdateCompanySegmentMemberAsync(int id, [FromBody] UpdateCompanySegmentMember updateCompanySegmentMember)
        {
            await companySegmentMemberService.UpdateCompanySegmentMemberAsync(id, updateCompanySegmentMember);
        }
    }
}
