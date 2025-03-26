using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class RequestForQuotationController(RequestForQuotationService requestForQuotationService) : Controller
    {
        [HttpPost("CreateRequestForQuotation")]
        public async Task<IActionResult> CreateRequestForQuotationAsync([FromBody] CreateRequestForQuotation createRequestForQuotation)
        {
            try
            {
                var result = await requestForQuotationService.CreateRequestForQuotationAsync(createRequestForQuotation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteRequestForQuotation")]
        public async Task DeleteRequestForQuotationAsync(int id)
        {
            await requestForQuotationService.DeleteRequestForQuotationAsync(id);
        }

        [HttpGet("GetAllRequestForQuotation")]
        public async Task<IActionResult> GetAllRequestForQuotationAsync()
        {
            try
            {
                var result = await requestForQuotationService.GetAllRequestForQuotationAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRequestForQuotationById")]
        public async Task<IActionResult> GetRequestForQuotationByIdAsync(int id)
        {
            try
            {
                var result = await requestForQuotationService.GetRequestForQuotationByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRequestForQuotation")]
        public async Task UpdateRequestForQuotationAsync(int id, [FromBody] UpdateRequestForQuotation updateRequestForQuotation)
        {
            await requestForQuotationService.UpdateRequestForQuotationAsync(id, updateRequestForQuotation);
        }
    }
}
