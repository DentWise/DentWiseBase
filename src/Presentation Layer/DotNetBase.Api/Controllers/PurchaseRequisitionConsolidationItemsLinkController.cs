using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PurchaseRequisitionConsolidationItemsLinkController(PurchaseRequisitionConsolidationItemsLinkService purchaseRequisitionConsolidationItemsLinkService) : Controller
    {
        [HttpPost("CreatePurchaseRequisitionConsolidationItemsLink")]
        public async Task<IActionResult> CreatePurchaseRequisitionConsolidationItemsLinkAsync([FromBody] CreatePurchaseRequisitionConsolidationItemsLink createPurchaseRequisitionConsolidationItemsLink)
        {
            try
            {
                var result = await purchaseRequisitionConsolidationItemsLinkService.CreatePurchaseRequisitionConsolidationItemsLinkAsync(createPurchaseRequisitionConsolidationItemsLink);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePurchaseRequisitionConsolidationItemsLink")]
        public async Task DeletePurchaseRequisitionConsolidationItemsLinkAsync(int id)
        {
            await purchaseRequisitionConsolidationItemsLinkService.DeletePurchaseRequisitionConsolidationItemsLinkAsync(id);
        }

        [HttpGet("GetAllPurchaseRequisitionConsolidationItemsLink")]
        public async Task<IActionResult> GetAllPurchaseRequisitionConsolidationItemsLinkAsync()
        {
            try
            {
                var result = await purchaseRequisitionConsolidationItemsLinkService.GetAllPurchaseRequisitionConsolidationItemsLinkAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPurchaseRequisitionConsolidationItemsLinkById")]
        public async Task<IActionResult> GetPurchaseRequisitionConsolidationItemsLinkByIdAsync(int id)
        {
            try
            {
                var result = await purchaseRequisitionConsolidationItemsLinkService.GetPurchaseRequisitionConsolidationItemsLinkByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePurchaseRequisitionConsolidationItemsLink")]
        public async Task UpdatePurchaseRequisitionConsolidationItemsLinkAsync(int id, [FromBody] UpdatePurchaseRequisitionConsolidationItemsLink updatePurchaseRequisitionConsolidationItemsLink)
        {
            await purchaseRequisitionConsolidationItemsLinkService.UpdatePurchaseRequisitionConsolidationItemsLinkAsync(id, updatePurchaseRequisitionConsolidationItemsLink);
        }
    }
}
