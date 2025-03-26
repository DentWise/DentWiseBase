using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class SupplierQuotationItemController(SupplierQuotationItemService supplierQuotationItemService) : Controller
    {
        [HttpPost("CreateSupplierQuotationItem")]
        public async Task<IActionResult> CreateSupplierQuotationItemAsync([FromBody] CreateSupplierQuotationItem createSupplierQuotationItem)
        {
            try
            {
                var result = await supplierQuotationItemService.CreateSupplierQuotationItemAsync(createSupplierQuotationItem);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteSupplierQuotationItem")]
        public async Task DeleteSupplierQuotationItemAsync(int id)
        {
            await supplierQuotationItemService.DeleteSupplierQuotationItemAsync(id);
        }

        [HttpGet("GetAllSupplierQuotationItem")]
        public async Task<IActionResult> GetAllSupplierQuotationItemAsync()
        {
            try
            {
                var result = await supplierQuotationItemService.GetAllSupplierQuotationItemAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSupplierQuotationItemById")]
        public async Task<IActionResult> GetSupplierQuotationItemByIdAsync(int id)
        {
            try
            {
                var result = await supplierQuotationItemService.GetSupplierQuotationItemByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSupplierQuotationItem")]
        public async Task UpdateSupplierQuotationItemAsync(int id, [FromBody] UpdateSupplierQuotationItem updateSupplierQuotationItem)
        {
            await supplierQuotationItemService.UpdateSupplierQuotationItemAsync(id, updateSupplierQuotationItem);
        }
    }
}
