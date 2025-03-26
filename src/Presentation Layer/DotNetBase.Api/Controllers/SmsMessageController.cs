using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class SmsMessageController(SmsMessageService smsMessageService) : Controller
    {
        [HttpPost("CreateSmsMessage")]
        public async Task<IActionResult> CreateSmsMessageAsync([FromBody] CreateSmsMessage createSmsMessage)
        {
            try
            {
                var result = await smsMessageService.CreateSmsMessageAsync(createSmsMessage);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllSmsMessage")]
        public async Task<IActionResult> GetAllSmsMessageAsync()
        {
            try
            {
                var result = await smsMessageService.GetAllSmsMessageAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSmsMessageById")]
        public async Task<IActionResult> GetSmsMessageByIdAsync(int id)
        {
            try
            {
                var result = await smsMessageService.GetSmsMessageByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
