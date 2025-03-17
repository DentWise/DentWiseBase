//using DotNetBase.Business.Identity.Services;
//using DotNetBase.Entities.Dto.RequestModels;
//using DotNetBase.Entities.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace DotNetBase.Api.Controllers
//{
//    public class ContactController(ContactService contactService) : Controller
//    {
//        [HttpPost("CreateContact")]
//        public async Task<IActionResult> CreateContactAsync([FromBody]CreateContactDto createContact)
//        {
//            try
//            {
//                var result = await contactService.CreateContactAsync(createContact);
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPut("DeleteContact")]
//        public async Task DeleteContactAsync(int id)
//        {
//            await contactService.DeleteContactAsync(id);
//        }

//        [HttpGet("GetAllContact")]
//        public async Task<IActionResult> GetAllContactsAsync()
//        {
//            try
//            {
//                var result = await contactService.GetAllContactsAsync();
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpGet("GetContactById")]
//        public async Task<IActionResult> GetContactByIdAsync(int id)
//        {
//            try
//            {
//                var result = await contactService.GetContactByIdAsync(id);
//                return Ok(result);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        [HttpPut("UpdateContact")]
//        public async Task UpdateContactAsync(int id, [FromBody]UpdateContactDto updateContact)
//        {
//            await contactService.UpdateContactAsync(id, updateContact);
//        }

//    }
//}
