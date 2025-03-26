using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PurchaseRequisitionController(PurchaseRequisitionService purchaseRequisitionService) : Controller
    {
        [HttpPost("CreatePurchaseRequisition")]
        public async Task<IActionResult> CreatePurchaseRequisitionAsync([FromBody] CreatePurchaseRequisition createPurchaseRequisition)
        {
            try
            {
                var result = await purchaseRequisitionService.CreatePurchaseRequisitionAsync(createPurchaseRequisition);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePurchaseRequisition")]
        public async Task DeletePurchaseRequisitionAsync(int id)
        {
            await purchaseRequisitionService.DeletePurchaseRequisitionAsync(id);
        }

        [HttpGet("GetAllPurchaseRequisition")]
        public async Task<IActionResult> GetAllPurchaseRequisitionAsync()
        {
            try
            {
                var result = await purchaseRequisitionService.GetAllPurchaseRequisitionAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseRequisitionById")]
        public async Task<IActionResult> GetPurchaseRequisitionByIdAsync(int id)
        {
            try
            {
                var result = await purchaseRequisitionService.GetPurchaseRequisitionByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePurchaseRequisition")]
        public async Task UpdatePurchaseRequisitionAsync(int id, [FromBody] UpdatePurchaseRequisition updatePurchaseRequisition)
        {
            await purchaseRequisitionService.UpdatePurchaseRequisitionAsync(id, updatePurchaseRequisition);
        }
    }
}
