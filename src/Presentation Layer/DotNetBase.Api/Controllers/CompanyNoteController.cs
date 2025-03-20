using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class CompanyNoteController(CompanyNoteService companyNoteService) : Controller
    {
        [HttpPost("CreateCompanyNote")]
        public async Task<IActionResult> CreateCompanyNoteAsync([FromBody] CreateCompanyNote createCompanyNote)
        {
            try
            {
                var result = await companyNoteService.CreateCompanyNoteAsync(createCompanyNote);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCompanyNote")]
        public async Task DeleteCompanyNoteAsync(int id)
        {
            await companyNoteService.DeleteCompanyNoteAsync(id);
        }

        [HttpGet("GetAllCompanyNote")]
        public async Task<IActionResult> GetAllCompanyNoteAsync()
        {
            try
            {
                var result = await companyNoteService.GetAllCompanyNoteAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanyNoteById")]
        public async Task<IActionResult> GetCompanyNoteByIdAsync(int id)
        {
            try
            {
                var result = await companyNoteService.GetCompanyNoteByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCompanyNote")]
        public async Task UpdateCompanyNoteAsync(int id, [FromBody] UpdateCompanyNote updateCompanyNote)
        {
            await companyNoteService.UpdateCompanyNoteAsync(id, updateCompanyNote);
        }
    }
}
