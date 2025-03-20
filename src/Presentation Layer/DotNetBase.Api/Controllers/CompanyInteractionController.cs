using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class CompanyInteractionController(CompanyInteractionService companyInteractionService) : Controller
    {
        [HttpPost("CreateCompanyInteraction")]
        public async Task<IActionResult> CreateCompanyInteractionAsync([FromBody] CreateCompanyInteraction createCompanyInteraction)
        {
            try
            {
                var result = await companyInteractionService.CreateCompanyInteractionAsync(createCompanyInteraction);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCompanyInteraction")]
        public async Task DeleteCompanyInteractionAsync(int id)
        {
            await companyInteractionService.DeleteCompanyInteractionAsync(id);
        }

        [HttpGet("GetAllCompanyInteraction")]
        public async Task<IActionResult> GetAllCompanyInteractionAsync()
        {
            try
            {
                var result = await companyInteractionService.GetAllCompanyInteractionAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanyInteractionById")]
        public async Task<IActionResult> GetCompanyInteractionByIdAsync(int id)
        {
            try
            {
                var result = await companyInteractionService.GetCompanyInteractionByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCompanyInteraction")]
        public async Task UpdateCompanyInteractionAsync(int id, [FromBody] UpdateCompanyInteraction updateCompanyInteraction)
        {
            await companyInteractionService.UpdateCompanyInteractionAsync(id, updateCompanyInteraction);
        }
    }
}
