using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ConsolidationStatusController(ConsolidationStatusService consolidationStatusService) : Controller
    {
        [HttpPost("CreateConsolidationStatus")]
        public async Task<IActionResult> CreateConsolidationStatusAsync([FromBody] CreateConsolidationStatus createConsolidationStatus)
        {
            try
            {
                var result = await consolidationStatusService.CreateConsolidationStatusAsync(createConsolidationStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteConsolidationStatus")]
        public async Task DeleteConsolidationStatusAsync(int id)
        {
            await consolidationStatusService.DeleteConsolidationStatusAsync(id);
        }

        [HttpGet("GetAllConsolidationStatus")]
        public async Task<IActionResult> GetAllConsolidationStatusAsync()
        {
            try
            {
                var result = await consolidationStatusService.GetAllConsolidationStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetConsolidationStatusById")]
        public async Task<IActionResult> GetConsolidationStatusByIdAsync(int id)
        {
            try
            {
                var result = await consolidationStatusService.GetConsolidationStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateConsolidationStatus")]
        public async Task UpdateConsolidationStatusAsync(int id, [FromBody] UpdateConsolidationStatus updateConsolidationStatus)
        {
            await consolidationStatusService.UpdateConsolidationStatusAsync(id, updateConsolidationStatus);
        }
    }
}
