using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class RequestForQuotationItemController(RequestForQuotationItemService requestForQuotationItemService) : Controller
    {
        [HttpPost("CreateRequestForQuotationItem")]
        public async Task<IActionResult> CreateRequestForQuotationItemAsync([FromBody] CreateRequestForQuotationItem createRequestForQuotationItem)
        {
            try
            {
                var result = await requestForQuotationItemService.CreateRequestForQuotationItemAsync(createRequestForQuotationItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteRequestForQuotationItem")]
        public async Task DeleteRequestForQuotationItemAsync(int id)
        {
            await requestForQuotationItemService.DeleteRequestForQuotationItemAsync(id);
        }

        [HttpGet("GetAllRequestForQuotationItem")]
        public async Task<IActionResult> GetAllRequestForQuotationItemAsync()
        {
            try
            {
                var result = await requestForQuotationItemService.GetAllRequestForQuotationItemAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRequestForQuotationItemById")]
        public async Task<IActionResult> GetRequestForQuotationItemByIdAsync(int id)
        {
            try
            {
                var result = await requestForQuotationItemService.GetRequestForQuotationItemByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRequestForQuotationItem")]
        public async Task UpdateRequestForQuotationItemAsync(int id, [FromBody] UpdateRequestForQuotationItem updateRequestForQuotationItem)
        {
            await requestForQuotationItemService.UpdateRequestForQuotationItemAsync(id, updateRequestForQuotationItem);
        }
    }
}
