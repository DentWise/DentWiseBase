using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class CompanyStatusController(CompanyStatusService companyStatusService) : Controller
    {
        [HttpPost("CreateCompanyStatus")]
        public async Task<IActionResult> CreateCompanyStatusAsync([FromBody] CreateCompanyStatus createCompanyStatus)
        {
            try
            {
                var result = await companyStatusService.CreateCompanyStatusAsync(createCompanyStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCompanyStatus")]
        public async Task DeleteCompanyStatusAsync(int id)
        {
            await companyStatusService.DeleteCompanyStatusAsync(id);
        }

        [HttpGet("GetAllCompanyStatus")]
        public async Task<IActionResult> GetAllCompanyStatusAsync()
        {
            try
            {
                var result = await companyStatusService.GetAllCompanyStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanyStatusById")]
        public async Task<IActionResult> GetCompanyStatusByIdAsync(int id)
        {
            try
            {
                var result = await companyStatusService.GetCompanyStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCompanyStatus")]
        public async Task UpdateCompanyStatusAsync(int id, [FromBody] UpdateCompanyStatus updateCompanyStatus)
        {
            await companyStatusService.UpdateCompanyStatusAsync(id, updateCompanyStatus);
        }
    }
}
