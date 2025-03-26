using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ProductController(ProductService productService) : Controller
    {
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProduct createProduct)
        {
            try
            {
                var result = await productService.CreateProductAsync(createProduct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteProduct")]
        public async Task DeleteProductAsync(int id)
        {
            await productService.DeleteProductAsync(id);
        }

        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            try
            {
                var result = await productService.GetAllProductAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            try
            {
                var result = await productService.GetProductByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task UpdateProductAsync(int id, [FromBody] UpdateProduct updateProduct)
        {
            await productService.UpdateProductAsync(id, updateProduct);
        }
    }
}
