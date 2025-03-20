using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class EmailThreadController(EmailThreadService emailThreadService) : Controller
    {
        [HttpPost("CreateEmailThread")]
        public async Task<IActionResult> CreateEmailThreadAsync([FromBody] CreateEmailThread createEmailThread)
        {
            try
            {
                var result = await emailThreadService.CreateEmailThreadAsync(createEmailThread);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetEmailThreadById")]
        public async Task<IActionResult> GetEmailThreadByIdAsync(int id)
        {
            try
            {
                var result = await emailThreadService.GetEmailThreadByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
