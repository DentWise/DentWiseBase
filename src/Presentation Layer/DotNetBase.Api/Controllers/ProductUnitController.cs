using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ProductUnitController(ProductUnitService productUnitService) : Controller
    {
        [HttpPost("CreateProductUnit")]
        public async Task<IActionResult> CreateProductUnitAsync([FromBody] CreateProductUnit createProductUnit)
        {
            try
            {
                var result = await productUnitService.CreateProductUnitAsync(createProductUnit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteProductUnit")]
        public async Task DeleteProductUnitAsync(int id)
        {
            await productUnitService.DeleteProductUnitAsync(id);
        }

        [HttpGet("GetAllProductUnit")]
        public async Task<IActionResult> GetAllProductUnitAsync()
        {
            try
            {
                var result = await productUnitService.GetAllProductUnitAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductUnitById")]
        public async Task<IActionResult> GetProductUnitByIdAsync(int id)
        {
            try
            {
                var result = await productUnitService.GetProductUnitByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProductUnit")]
        public async Task UpdateProductUnitAsync(int id, [FromBody] UpdateProductUnit updateProductUnit)
        {
            await productUnitService.UpdateProductUnitAsync(id, updateProductUnit);
        }
    }
}
