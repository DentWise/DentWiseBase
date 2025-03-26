using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class SupplierProductController(SupplierProductService supplierProductService) : Controller
    {
        [HttpPost("CreateSupplierProduct")]
        public async Task<IActionResult> CreateSupplierProductAsync([FromBody] CreateSupplierProduct createSupplierProduct)
        {
            try
            {
                var result = await supplierProductService.CreateSupplierProductAsync(createSupplierProduct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteSupplierProduct")]
        public async Task DeleteSupplierProductAsync(int id)
        {
            await supplierProductService.DeleteSupplierProductAsync(id);
        }

        [HttpGet("GetAllSupplierProduct")]
        public async Task<IActionResult> GetAllSupplierProductAsync()
        {
            try
            {
                var result = await supplierProductService.GetAllSupplierProductAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSupplierProductById")]
        public async Task<IActionResult> GetSupplierProductByIdAsync(int id)
        {
            try
            {
                var result = await supplierProductService.GetSupplierProductByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSupplierProduct")]
        public async Task UpdateSupplierProductAsync(int id, [FromBody] UpdateSupplierProduct updateSupplierProduct)
        {
            await supplierProductService.UpdateSupplierProductAsync(id, updateSupplierProduct);
        }
    }
}
