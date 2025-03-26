using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class RequisitionStatusController(RequisitionStatusService requisitionStatusService) : Controller
    {
        [HttpPost("CreateRequisitionStatus")]
        public async Task<IActionResult> CreateRequisitionStatusAsync([FromBody] CreateRequisitionStatus createRequisitionStatus)
        {
            try
            {
                var result = await requisitionStatusService.CreateRequisitionStatusAsync(createRequisitionStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteRequisitionStatus")]
        public async Task DeleteRequisitionStatusAsync(int id)
        {
            await requisitionStatusService.DeleteRequisitionStatusAsync(id);
        }

        [HttpGet("GetAllRequisitionStatus")]
        public async Task<IActionResult> GetAllRequisitionStatusAsync()
        {
            try
            {
                var result = await requisitionStatusService.GetAllRequisitionStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRequisitionStatusById")]
        public async Task<IActionResult> GetRequisitionStatusByIdAsync(int id)
        {
            try
            {
                var result = await requisitionStatusService.GetRequisitionStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateRequisitionStatus")]
        public async Task UpdateRequisitionStatusAsync(int id, [FromBody] UpdateRequisitionStatus updateRequisitionStatus)
        {
            await requisitionStatusService.UpdateRequisitionStatusAsync(id, updateRequisitionStatus);
        }
    }
}
