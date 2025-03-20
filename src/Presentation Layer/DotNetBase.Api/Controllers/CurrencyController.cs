using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class CurrencyController(CurrencyService currencyService) : Controller
    {
        [HttpPost("CreateCurrency")]
        public async Task<IActionResult> CreateCurrencyAsync([FromBody] CreateCurrency createCurrency)
        {
            try
            {
                var result = await currencyService.CreateCurrencyAsync(createCurrency);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCurrency")]
        public async Task DeleteCurrencyAsync(int id)
        {
            await currencyService.DeleteCurrencyAsync(id);
        }

        [HttpGet("GetAllCurrency")]
        public async Task<IActionResult> GetAllCurrencyAsync()
        {
            try
            {
                var result = await currencyService.GetAllCurrencyAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCurrencyById")]
        public async Task<IActionResult> GetCurrencyByIdAsync(int id)
        {
            try
            {
                var result = await currencyService.GetCurrencyByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCurrency")]
        public async Task UpdateCurrencyAsync(int id, [FromBody] UpdateCurrency updateCurrency)
        {
            await currencyService.UpdateCurrencyAsync(id, updateCurrency);
        }
    }
}
