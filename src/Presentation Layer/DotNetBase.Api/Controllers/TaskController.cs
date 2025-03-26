using DotNetBase.Business.Identity.Interfaces;
using DotNetBase.Business.Identity.Services;
using DotNetBase.Entities.Dto.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBase.Api.Controllers
{
    public class TaskController(TaskService taskService) : Controller
    {
        [HttpPost("CreateTask")]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTask createTask)
        {
            try
            {
                var result = await taskService.CreateTaskAsync(createTask);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("DeleteTask")]
        public async Task DeleteTaskAsync(int id)
        {
            await taskService.DeleteTaskAsync(id);
        }

        [HttpGet("GetAllTask")]
        public async Task<IActionResult> GetAllTaskAsync()
        {
            try
            {
                var result = await taskService.GetAllTaskAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTaskById")]
        public async Task<IActionResult> GetTaskByIdAsync(int id)
        {
            try
            {
                var result = await taskService.GetTaskByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateTask")]
        public async Task UpdateTaskAsync(int id, [FromBody] UpdateTask updateTask)
        {
            await taskService.UpdateTaskAsync(id, updateTask);
        }
    }
}
