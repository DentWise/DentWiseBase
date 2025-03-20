using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PaymentStatusController(PaymentStatusService paymentStatusService) : Controller
    {
        [HttpPost("CreatePaymentStatus")]
        public async Task<IActionResult> CreatePaymentStatusAsync([FromBody] CreatePaymentStatus createPaymentStatus)
        {
            try
            {
                var result = await paymentStatusService.CreatePaymentStatusAsync(createPaymentStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePaymentStatus")]
        public async Task DeletePaymentStatusAsync(int id)
        {
            await paymentStatusService.DeletePaymentStatusAsync(id);
        }

        [HttpGet("GetAllPaymentStatus")]
        public async Task<IActionResult> GetAllPaymentStatusAsync()
        {
            try
            {
                var result = await paymentStatusService.GetAllPaymentStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPaymentStatusById")]
        public async Task<IActionResult> GetPaymentStatusByIdAsync(int id)
        {
            try
            {
                var result = await paymentStatusService.GetPaymentStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePaymentStatus")]
        public async Task UpdatePaymentStatusAsync(int id, [FromBody] UpdatePaymentStatus updatePaymentStatus)
        {
            await paymentStatusService.UpdatePaymentStatusAsync(id, updatePaymentStatus);
        }
    }
}
