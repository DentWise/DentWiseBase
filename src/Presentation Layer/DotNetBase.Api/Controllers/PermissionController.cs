using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class PermissionController(PermissionService permissionService) : Controller
    {
        [HttpPost("CreatePermission")]
        public async Task<IActionResult> CreatePermissionAsync([FromBody] CreatePermission createPermission)
        {
            try
            {
                var result = await permissionService.CreatePermissionAsync(createPermission);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeletePermission")]
        public async Task DeletePermissionAsync(int id)
        {
            await permissionService.DeletePermissionAsync(id);
        }

        [HttpGet("GetAllPermission")]
        public async Task<IActionResult> GetAllPermissionAsync()
        {
            try
            {
                var result = await permissionService.GetAllPermissionAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPermissionById")]
        public async Task<IActionResult> GetPermissionByIdAsync(int id)
        {
            try
            {
                var result = await permissionService.GetPermissionByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
