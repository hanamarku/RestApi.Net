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


        [HttpGet("gettasks")]
        public ActionResult<List<Taskk>> GetTasksOfEmployees(int id)
        {
            var tasks = _context.Tasks.Where(x => x.EmployeeId == id).ToList();
            return tasks;
        }

        [HttpGet("GetAllEmplyees")]
        public async Task<ActionResult<List<User>>> GetEm()
        {
            return Ok(await _service.GetAllAsync());
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




        //Employee Area
        //[HttpPost]
        //Task<ActionResult<ServiceResponse<string>>> Employee_CreateTask(EmployeeNewTask data)
        //{

        //}


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
