using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ProductCommissionController(ProductCommissionService productCommissionService) : Controller
    {
        [HttpPost("CreateProductCommission")]
        public async Task<IActionResult> CreateProductCommissionAsync([FromBody] CreateProductCommission createProductCommission)
        {
            try
            {
                var result = await productCommissionService.CreateProductCommissionAsync(createProductCommission);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllProductCommission")]
        public async Task<IActionResult> GetAllProductCommissionAsync()
        {
            try
            {
                var result = await productCommissionService.GetAllProductCommissionAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductCommissionById")]
        public async Task<IActionResult> GetProductCommissionByIdAsync(int id)
        {
            try
            {
                var result = await productCommissionService.GetProductCommissionByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProductCommission")]
        public async Task UpdateProductCommissionAsync(int id, [FromBody] UpdateProductCommission updateProductCommission)
        {
            await productCommissionService.UpdateProductCommissionAsync(id, updateProductCommission);
        }
    }
}
