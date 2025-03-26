using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class SupplierQuotationController(SupplierQuotationService supplierQuotationService) : Controller
    {
        [HttpPost("CreateSupplierQuotation")]
        public async Task<IActionResult> CreateSupplierQuotationAsync([FromBody] CreateSupplierQuotation createSupplierQuotation)
        {
            try
            {
                var result = await supplierQuotationService.CreateSupplierQuotationAsync(createSupplierQuotation);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteSupplierQuotation")]
        public async Task DeleteSupplierQuotationAsync(int id)
        {
            await supplierQuotationService.DeleteSupplierQuotationAsync(id);
        }

        [HttpGet("GetAllSupplierQuotation")]
        public async Task<IActionResult> GetAllSupplierQuotationAsync()
        {
            try
            {
                var result = await supplierQuotationService.GetAllSupplierQuotationAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSupplierQuotationById")]
        public async Task<IActionResult> GetSupplierQuotationByIdAsync(int id)
        {
            try
            {
                var result = await supplierQuotationService.GetSupplierQuotationByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSupplierQuotation")]
        public async Task UpdateSupplierQuotationAsync(int id, [FromBody] UpdateSupplierQuotation updateSupplierQuotation)
        {
            await supplierQuotationService.UpdateSupplierQuotationAsync(id, updateSupplierQuotation);
        }
    }
}
