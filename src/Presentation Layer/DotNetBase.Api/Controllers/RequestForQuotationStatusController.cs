using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class RequestForQuotationStatusController(RequestForQuotationStatusService requestForQuotationStatusService) : Controller
    {
        [HttpPost("CreateRequestForQuotationStatus")]
        public async Task<IActionResult> CreateRequestForQuotationStatusAsync([FromBody] CreateRequestForQuotationStatus createRequestForQuotationStatus)
        {
            try
            {
                var result = await requestForQuotationStatusService.CreateRequestForQuotationStatusAsync(createRequestForQuotationStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteRequestForQuotationStatusStatus")]
        public async Task DeleteRequestForQuotationStatusAsync(int id)
        {
            await requestForQuotationStatusService.DeleteRequestForQuotationStatusAsync(id);
        }

        [HttpGet("GetAllRequestForQuotationStatus")]
        public async Task<IActionResult> GetAllRequestForQuotationStatusAsync()
        {
            try
            {
                var result = await requestForQuotationStatusService.GetAllRequestForQuotationStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRequestForQuotationStatusById")]
        public async Task<IActionResult> GetRequestForQuotationStatusByIdAsync(int id)
        {
            try
            {
                var result = await requestForQuotationStatusService.GetRequestForQuotationStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRequestForQuotationStatus")]
        public async Task UpdateRequestForQuotationStatusAsync(int id, [FromBody] UpdateRequestForQuotationStatus updateRequestForQuotationStatus)
        {
            await requestForQuotationStatusService.UpdateRequestForQuotationStatusAsync(id, updateRequestForQuotationStatus);
        }
    }
}
