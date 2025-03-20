using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Api.Controllers
{
    public class InteractionAttachmentController(InteractionAttachmentService interactionAttachmentService) : Controller
    {
        [HttpPost("CreateInteractionAttachment")]
        public async Task<IActionResult> CreateInteractionAttachmentAsync([FromBody] CreateInteractionAttachment createInteractionAttachment)
        {
            try
            {
                var result = await interactionAttachmentService.CreateInteractionAttachmentAsync(createInteractionAttachment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteInteractionAttachment")]
        public async Task DeleteInteractionAttachmentAsync(int id)
        {
            await interactionAttachmentService.DeleteInteractionAttachmentAsync(id);
        }

        [HttpGet("GetAllInteractionAttachment")]
        public async Task<IActionResult> GetAllInteractionAttachmentAsync()
        {
            try
            {
                var result = await interactionAttachmentService.GetAllInteractionAttachmentAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetInteractionAttachmentById")]
        public async Task<IActionResult> GetInteractionAttachmentByIdAsync(int id)
        {
            try
            {
                var result = await interactionAttachmentService.GetInteractionAttachmentByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
