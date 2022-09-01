using ClassLibraryModels;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data;
using restApiProject.Data.Services;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ITaskService _service;

        public TaskController(AppDbContext context, ITaskService taskService)
        {
            _context = context;
            _service = taskService;
        }


        [HttpPost("CreateTask")]
        public async Task<ActionResult<ServiceResponse<string>>> createTask(NewTaskVM data)
        {
            var response = await _service.AddTaskAsync(data);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpPut("Mark Task As Completed {id}")]
        public async Task<ActionResult<ServiceResponse<string>>> MarkTaskAsCompleted(int id)
        {
            var response = await _service.MarkTaskAsCompleted(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpDelete("DeleteTask {id}")]
        public async Task<ActionResult<ServiceResponse<string>>> RemoveTask(int id)
        {
            var response = await _service.DeleteAsync(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
