using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class QuotationApprovalStatusController(QuotationApprovalStatusService quotationApprovalStatusService) : Controller
    {
        [HttpPost("CreateQuotationApprovalStatus")]
        public async Task<IActionResult> CreateQuotationApprovalStatusAsync([FromBody] CreateQuotationApprovalStatus createQuotationApprovalStatus)
        {
            try
            {
                var result = await quotationApprovalStatusService.CreateQuotationApprovalStatusAsync(createQuotationApprovalStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteQuotationApprovalStatus")]
        public async Task DeleteQuotationApprovalStatusAsync(int id)
        {
            await quotationApprovalStatusService.DeleteQuotationApprovalStatusAsync(id);
        }

        [HttpGet("GetAllQuotationApprovalStatus")]
        public async Task<IActionResult> GetAllQuotationApprovalStatusAsync()
        {
            try
            {
                var result = await quotationApprovalStatusService.GetAllQuotationApprovalStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetQuotationApprovalStatusById")]
        public async Task<IActionResult> GetQuotationApprovalStatusByIdAsync(int id)
        {
            try
            {
                var result = await quotationApprovalStatusService.GetQuotationApprovalStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateQuotationApprovalStatus")]
        public async Task UpdateQuotationApprovalStatusAsync(int id, [FromBody] UpdateQuotationApprovalStatus updateQuotationApprovalStatus)
        {
            await quotationApprovalStatusService.UpdateQuotationApprovalStatusAsync(id, updateQuotationApprovalStatus);
        }
    }
}
