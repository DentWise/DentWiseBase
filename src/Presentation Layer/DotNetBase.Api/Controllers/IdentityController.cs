using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class IdentityController(UserService userService) : Controller
    {
        public async Task<IActionResult> SignUp(CreateUserDto user)
        {
            try
            {
                var result = await userService.CreateUserAsync(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
