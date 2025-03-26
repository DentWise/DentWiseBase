using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class UserController(UserService userService) : Controller
    {
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUser createUser)
        {
            try
            {
                var result = await userService.CreateUserAsync(createUser);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteUser")]
        public async Task DeleteUserAsync(int id)
        {
            await userService.DeleteUserAsync(id);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            try
            {
                var result = await userService.GetAllUsersAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            try
            {
                var result = await userService.GetUserByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateUser")]
        public async Task UpdateUserAsync(int id, [FromBody] UpdateUser updateUser)
        {
            await userService.UpdateUserAsync(id, updateUser);
        }
    }
}
