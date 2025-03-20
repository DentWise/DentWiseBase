using DotNetBase.Business.Identity.Services;
using DotNetBase.EFCore.Entities;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Api.Controllers
{
    public class CompanySegmentController(CompanySegmentService companySegmentService) : Controller
    {
        [HttpPost("CreateCompanySegment")]
        public async Task<IActionResult> CreateCompanySegmentAsync([FromBody] CreateCompanySegment createCompanySegment)
        {
            try
            {
                var result = await companySegmentService.CreateCompanySegmentAsync(createCompanySegment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCompanySegment")]
        public async Task DeleteCompanySegmentAsync(int id)
        {
            await companySegmentService.DeleteCompanySegmentAsync(id);
        }

        [HttpGet("GetAllCompanySegment")]
        public async Task<IActionResult> GetAllCompanySegmentAsync()
        {
            try
            {
                var result = await companySegmentService.GetAllCompanySegmentAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanySegmentById")]
        public async Task<IActionResult> GetCompanySegmentByIdAsync(int id)
        {
            try
            {
                var result = await companySegmentService.GetCompanySegmentByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCompanySegment")]
        public async Task UpdateCompanySegmentAsync(int id, [FromBody] UpdateCompanySegment updateCompanySegment)
        {
            await companySegmentService.UpdateCompanySegmentAsync(id, updateCompanySegment);
        }
    }
}
