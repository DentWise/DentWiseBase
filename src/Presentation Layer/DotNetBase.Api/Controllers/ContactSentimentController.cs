using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ContactSentimentController(ContactSentimentService contactSentimentService) : Controller
    {
        [HttpPost("CreateContactSentiment")]
        public async Task<IActionResult> CreateContactSentimentAsync([FromBody] CreateContactSentiment createContactSentiment)
        {
            try
            {
                var result = await contactSentimentService.CreateContactSentimentAsync(createContactSentiment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteContactSentiment")]
        public async Task DeleteContactSentimentAsync(int id)
        {
            await contactSentimentService.DeleteContactSentimentAsync(id);
        }

        [HttpGet("GetAllContactSentiment")]
        public async Task<IActionResult> GetAllContactSentimentAsync()
        {
            try
            {
                var result = await contactSentimentService.GetAllContactSentimentAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetContactSentimentById")]
        public async Task<IActionResult> GetContactSentimentByIdAsync(int id)
        {
            try
            {
                var result = await contactSentimentService.GetContactSentimentByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateContactSentiment")]
        public async Task UpdateContactSentimentAsync(int id, [FromBody] UpdateContactSentiment updateContactSentiment)
        {
            await contactSentimentService.UpdateContactSentimentAsync(id, updateContactSentiment);
        }
    }
}
