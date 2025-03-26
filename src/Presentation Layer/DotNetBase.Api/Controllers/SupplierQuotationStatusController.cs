using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class SupplierQuotationStatusController(SupplierQuotationStatusService supplierQuotationStatusService) : Controller
    {
        [HttpPost("CreateSupplierQuotationStatus")]
        public async Task<IActionResult> CreateSupplierQuotationStatusAsync([FromBody] CreateSupplierQuotationStatus createSupplierQuotationStatus)
        {
            try
            {
                var result = await supplierQuotationStatusService.CreateSupplierQuotationStatusAsync(createSupplierQuotationStatus);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteSupplierQuotationStatus")]
        public async Task DeleteSupplierQuotationStatusAsync(int id)
        {
            await supplierQuotationStatusService.DeleteSupplierQuotationStatusAsync(id);
        }

        [HttpGet("GetAllSupplierQuotationStatus")]
        public async Task<IActionResult> GetAllSupplierQuotationStatusAsync()
        {
            try
            {
                var result = await supplierQuotationStatusService.GetAllSupplierQuotationStatusAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSupplierQuotationStatusById")]
        public async Task<IActionResult> GetSupplierQuotationStatusByIdAsync(int id)
        {
            try
            {
                var result = await supplierQuotationStatusService.GetSupplierQuotationStatusByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSupplierQuotationStatus")]
        public async Task UpdateSupplierQuotationStatusAsync(int id, [FromBody] UpdateSupplierQuotationStatus updateSupplierQuotationStatus)
        {
            await supplierQuotationStatusService.UpdateSupplierQuotationStatusAsync(id, updateSupplierQuotationStatus);
        }
    }
}
