using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PurchaseOrderController(PurchaseOrderService purchaseOrderService) : Controller
    {
        [HttpPost("CreatePurchaseOrder")]
        public async Task<IActionResult> CreatePurchaseOrderAsync([FromBody] CreatePurchaseOrder createPurchaseOrder)
        {
            try
            {
                var result = await purchaseOrderService.CreatePurchaseOrderAsync(createPurchaseOrder);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePurchaseOrder")]
        public async Task DeletePurchaseOrderAsync(int id)
        {
            await purchaseOrderService.DeletePurchaseOrderAsync(id);
        }

        [HttpGet("GetAllPurchaseOrder")]
        public async Task<IActionResult> GetAllPurchaseOrderAsync()
        {
            try
            {
                var result = await purchaseOrderService.GetAllPurchaseOrderAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseOrderById")]
        public async Task<IActionResult> GetPurchaseOrderByIdAsync(int id)
        {
            try
            {
                var result = await purchaseOrderService.GetPurchaseOrderByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
