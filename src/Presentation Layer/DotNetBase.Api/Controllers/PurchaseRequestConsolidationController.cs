using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PurchaseRequestConsolidationController(PurchaseRequestConsolidationService purchaseRequestConsolidationService) : Controller
    {
        [HttpPost("CreatePurchaseRequestConsolidation")]
        public async Task<IActionResult> CreatePurchaseRequestConsolidationAsync([FromBody] CreatePurchaseRequestConsolidation createPurchaseRequestConsolidation)
        {
            try
            {
                var result = await purchaseRequestConsolidationService.CreatePurchaseRequestConsolidationAsync(createPurchaseRequestConsolidation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePurchaseRequestConsolidation")]
        public async Task DeletePurchaseRequestConsolidationAsync(int id)
        {
            await purchaseRequestConsolidationService.DeletePurchaseRequestConsolidationAsync(id);
        }

        [HttpGet("GetAllPurchaseRequestConsolidation")]
        public async Task<IActionResult> GetAllPurchaseRequestConsolidationAsync()
        {
            try
            {
                var result = await purchaseRequestConsolidationService.GetAllPurchaseRequestConsolidationAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseRequestConsolidationById")]
        public async Task<IActionResult> GetPurchaseRequestConsolidationByIdAsync(int id)
        {
            try
            {
                var result = await purchaseRequestConsolidationService.GetPurchaseRequestConsolidationByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePurchaseRequestConsolidation")]
        public async Task UpdatePurchaseRequestConsolidationAsync(int id, [FromBody] UpdatePurchaseRequestConsolidation updatePurchaseRequestConsolidation)
        {
            await purchaseRequestConsolidationService.UpdatePurchaseRequestConsolidationAsync(id, updatePurchaseRequestConsolidation);
        }
    }
}
