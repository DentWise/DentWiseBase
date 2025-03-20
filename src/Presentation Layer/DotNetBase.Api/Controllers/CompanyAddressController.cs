using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class CompanyAddressController(CompanyAddressService companyAddressService) : Controller
    {
        [HttpPost("CreateCompanyAddress")]
        public async Task<IActionResult> CreateCompanyAddressAsync([FromBody] CreateCompanyAddress createClinicPayment)
        {
            try
            {
                var result = await companyAddressService.CreateCompanyAddressAsync(createClinicPayment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteCompanyAddress")]
        public async Task DeleteCompanyAddressAsync(int id)
        {
            await companyAddressService.DeleteCompanyAddressAsync(id);
        }

        [HttpGet("GetAllCompanyAddress")]
        public async Task<IActionResult> GetAllCompanyAddressAsync()
        {
            try
            {
                var result = await companyAddressService.GetAllCompanyAddressAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetCompanyAddressById")]
        public async Task<IActionResult> GetCompanyAddressByIdAsync(int id)
        {
            try
            {
                var result = await companyAddressService.GetCompanyAddressByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateCompanyAddress")]
        public async Task UpdateCompanyAddressAsync(int id, [FromBody] UpdateCompanyAddress updateClinicPayment)
        {
            await companyAddressService.UpdateCompanyAddressAsync(id, updateClinicPayment);
        }
    }
}
