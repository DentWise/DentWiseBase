//using DotNetBase.Business.Identity.Interfaces;
//using DotNetBase.Business.Identity.Services;
//using DotNetBase.Entities.Dto.RequestModels;
//using DotNetBase.Entities.Organization;
//using Microsoft.AspNetCore.Mvc;
//using Task = System.Threading.Tasks.Task;

//namespace DotNetBase.Api.Controllers
//{
//    public class CompanyController(CompanyService companyService) : Controller
//    {
//        [HttpPost("CreateCompany")]
//        public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyCreateDto createCompany)
//        {
//            try
//            {
//                var result = await companyService.CreateCompanyAsync(createCompany);
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPut("DeleteCompany")]
//        public async Task DeleteCompanyAsync(int id)
//        {
//            await companyService.DeleteCompanyAsync(id);
//        }

//        [HttpGet("GetAllCompany")]
//        public async Task<IActionResult> GetAllCompanyAsync()
//        {
//            try
//            {
//                var result = await companyService.GetAllCompanyAsync();
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("GetCompanyById")]
//        public async Task<IActionResult> GetCompanyByIdAsync(int id)
//        {
//            try
//            {
//                var result = await companyService.GetCompanyByIdAsync(id);
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPut("UpdateCompany")]
//        public async Task UpdateCompanyAsync(int id, [FromBody] CompanyUpdateDto updateCompany)
//        {
//            await companyService.UpdateCompanyAsync(id, updateCompany);
//        }

//    }
//}
