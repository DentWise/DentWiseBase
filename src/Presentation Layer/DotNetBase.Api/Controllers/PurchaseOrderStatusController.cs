using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PurchaseOrderStatusController(PurchaseOrderStatusService purchaseOrderStatusService) : Controller
    {
        [HttpPost("CreatePurchaseOrderStatus")]
        public async Task<IActionResult> CreatePurchaseOrderStatusAsync([FromBody] CreatePurchaseOrderStatus createPurchaseOrderStatus)
        {
            try
            {
                var result = await purchaseOrderStatusService.CreatePurchaseOrderStatusAsync(createPurchaseOrderStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePurchaseOrderStatus")]
        public async Task DeletePurchaseOrderStatusAsync(int id)
        {
            await purchaseOrderStatusService.DeletePurchaseOrderStatusAsync(id);
        }

        [HttpGet("GetAllPurchaseOrderStatus")]
        public async Task<IActionResult> GetAllPurchaseOrderStatusAsync()
        {
            try
            {
                var result = await purchaseOrderStatusService.GetAllPurchaseOrderStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseOrderStatusById")]
        public async Task<IActionResult> GetPurchaseOrderStatusByIdAsync(int id)
        {
            try
            {
                var result = await purchaseOrderStatusService.GetPurchaseOrderStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePurchaseOrderStatus")]
        public async Task UpdatePurchaseOrderStatusAsync(int id, [FromBody] UpdatePurchaseOrderStatus updatePurchaseOrderStatus)
        {
            await purchaseOrderStatusService.UpdatePurchaseOrderStatusAsync(id, updatePurchaseOrderStatus);
        }
    }
}
