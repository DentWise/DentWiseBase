using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PurchaseOrderItemController(PurchaseOrderItemService purchaseOrderItemService) : Controller
    {
        [HttpPost("CreatePurchaseOrderItem")]
        public async Task<IActionResult> CreatePurchaseOrderItemAsync([FromBody] CreatePurchaseOrderItem createPurchaseOrderItem)
        {
            try
            {
                var result = await purchaseOrderItemService.CreatePurchaseOrderItemAsync(createPurchaseOrderItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePurchaseOrderItem")]
        public async Task DeletePurchaseOrderItemAsync(int id)
        {
            await purchaseOrderItemService.DeletePurchaseOrderItemAsync(id);
        }

        [HttpGet("GetAllPurchaseOrderItem")]
        public async Task<IActionResult> GetAllPurchaseOrderItemAsync()
        {
            try
            {
                var result = await purchaseOrderItemService.GetAllPurchaseOrderItemAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseOrderItemById")]
        public async Task<IActionResult> GetPurchaseOrderItemByIdAsync(int id)
        {
            try
            {
                var result = await purchaseOrderItemService.GetPurchaseOrderItemByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePurchaseOrderItem")]
        public async Task UpdatePurchaseOrderItemAsync(int id, [FromBody] UpdatePurchaseOrderItem updatePurchaseOrderItem)
        {
            await purchaseOrderItemService.UpdatePurchaseOrderItemAsync(id, updatePurchaseOrderItem);
        }
    }
}
