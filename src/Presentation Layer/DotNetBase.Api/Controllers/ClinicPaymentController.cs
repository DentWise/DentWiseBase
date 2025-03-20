using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;
using Task = System.Threading.Tasks.Task;

namespace DotNetBase.Api.Controllers
{
    public class ClinicPaymentController(ClinicPaymentService clinicPaymentService) : Controller
    {
        [HttpPost("CreateClinicPayment")]
        public async Task<IActionResult> CreateClinicPaymentAsync([FromBody] CreateClinicPayment createClinicPayment)
        {
            try
            {
                var result = await clinicPaymentService.CreateClinicPaymentAsync(createClinicPayment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteClinicPayment")]
        public async Task DeleteClinicPaymentAsync(int id)
        {
            await clinicPaymentService.DeleteClinicPaymentAsync(id);
        }

        [HttpGet("GetAllClinicPayment")]
        public async Task<IActionResult> GetAllClinicPaymentAsync()
        {
            try
            {
                var result = await clinicPaymentService.GetAllClinicPaymentAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetClinicPaymentById")]
        public async Task<IActionResult> GetClinicPaymentByIdAsync(int id)
        {
            try
            {
                var result = await clinicPaymentService.GetClinicPaymentByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateClinicPayment")]
        public async Task UpdateClinicPaymentAsync(int id, [FromBody] UpdateClinicPayment updateClinicPayment)
        {
            await clinicPaymentService.UpdateClinicPaymentAsync(id, updateClinicPayment);
        }
    }
}
