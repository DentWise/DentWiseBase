using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ConsolidatedRequisitionItemController(ConsolidatedRequisitionItemService consolidatedRequisitionItemService) : Controller
    {
        [HttpPost("CreateConsolidatedRequisitionItem")]
        public async Task<IActionResult> CreateConsolidatedRequisitionItemAsync([FromBody] CreateConsolidatedRequisitionItem createConsolidatedRequisitionItem)
        {
            try
            {
                var result = await consolidatedRequisitionItemService.CreateConsolidatedRequisitionItemAsync(createConsolidatedRequisitionItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteConsolidatedRequisitionItem")]
        public async Task DeleteConsolidatedRequisitionItemAsync(int id)
        {
            await consolidatedRequisitionItemService.DeleteConsolidatedRequisitionItemAsync(id);
        }

        [HttpGet("GetAllConsolidatedRequisitionItem")]
        public async Task<IActionResult> GetAllConsolidatedRequisitionItemAsync()
        {
            try
            {
                var result = await consolidatedRequisitionItemService.GetAllConsolidatedRequisitionItemAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetConsolidatedRequisitionItemById")]
        public async Task<IActionResult> GetConsolidatedRequisitionItemByIdAsync(int id)
        {
            try
            {
                var result = await consolidatedRequisitionItemService.GetConsolidatedRequisitionItemByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateConsolidatedRequisitionItem")]
        public async Task UpdateConsolidatedRequisitionItemAsync(int id, [FromBody] UpdateConsolidatedRequisitionItem updateConsolidatedRequisitionItem)
        {
            await consolidatedRequisitionItemService.UpdateConsolidatedRequisitionItemAsync(id, updateConsolidatedRequisitionItem);
        }
    }
}
