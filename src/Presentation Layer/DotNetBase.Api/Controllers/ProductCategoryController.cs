using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class ProductCategoryController(ProductCategoryService productCategoryService) : Controller
    {
        [HttpPost("CreateProductCategory")]
        public async Task<IActionResult> CreateProductCategoryAsync([FromBody] CreateProductCategory createProductCategory)
        {
            try
            {
                var result = await productCategoryService.CreateProductCategoryAsync(createProductCategory);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllProductCategory")]
        public async Task<IActionResult> GetAllProductCategoryAsync()
        {
            try
            {
                var result = await productCategoryService.GetAllProductCategoryAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductCategoryById")]
        public async Task<IActionResult> GetProductCategoryByIdAsync(int id)
        {
            try
            {
                var result = await productCategoryService.GetProducCategoryByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProductCategory")]
        public async Task UpdateProductCategoryAsync(int id, [FromBody] UpdateProductCategory updateProductCategory)
        {
            await productCategoryService.UpdateProductCategoryAsync(id, updateProductCategory);
        }
    }
}
