using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class RequisitionItemController(RequisitionItemService requisitionItemService) : Controller
    {
        [HttpPost("CreateRequisitionItem")]
        public async Task<IActionResult> CreateRequisitionItemAsync([FromBody] CreateRequisitionItem createRequisitionItem)
        {
            try
            {
                var result = await requisitionItemService.CreateRequisitionItemAsync(createRequisitionItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteRequisitionItemStatus")]
        public async Task DeleteRequisitionItemAsync(int id)
        {
            await requisitionItemService.DeleteRequisitionItemAsync(id);
        }

        [HttpGet("GetAllRequisitionItem")]
        public async Task<IActionResult> GetAllRequisitionItemAsync()
        {
            try
            {
                var result = await requisitionItemService.GetAllRequisitionItemAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRequisitionItemById")]
        public async Task<IActionResult> GetRequisitionItemByIdAsync(int id)
        {
            try
            {
                var result = await requisitionItemService.GetRequisitionItemByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRequisitionItem")]
        public async Task UpdateRequisitionItemAsync(int id, [FromBody] UpdateRequisitionItem updateRequisitionItem)
        {
            await requisitionItemService.UpdateRequisitionItemAsync(id, updateRequisitionItem);
        }
    }
}
