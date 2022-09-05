using ClassLibraryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restApiProject.Data.Services;
using restApiProject.Data.ViewModels;

namespace restApiProject.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService taskService)
        {
            _service = taskService;
        }



        //Administrator can create new tasks

        [HttpPost("CreateTask"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<string>>> createTask(NewTaskVM data)
        {
            var response = await _service.AddTaskAsync(data);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



        [HttpPut("UpdateTask"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<string>>> UpdateTask(int id, NewTaskVM data)
        {
            var response = await _service.UpdateTaskAsync(id, data);
            if (string.IsNullOrEmpty(response.Message))
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


        [HttpDelete("DeleteTask {id}"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<string>>> RemoveTask(int id)
        {
            var response = await _service.DeleteAsync(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



        [HttpPut("Mark Task As Completed {id}"), Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponse<string>>> MarkTaskAsCompleted(int id)
        {
            var response = await _service.MarkTaskAsCompleted(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }





        //Employee Area

        //Employee can view all tasks that are related to the projects he is part of 

        [HttpGet("GetTasksOfEmployee"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<List<Taskk>>> GetTasksOfEmployees()
        {
            var tasks = await _service.GetTasksOfEmployees();

            return tasks;
        }

        //Employee can view all tasks that are related to a specific projects he is part of 

        [HttpGet("GetTasksProjectEmployee"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<List<Taskk>>> GetTasksProjectOfEmployee(int projectId)
        {
            var tasksOfPro = await _service.GetTasksProjectOfEmployee(projectId);

            return tasksOfPro;
        }

        [HttpGet("GetProjectEmployee"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<List<Employee_Project>>> GetProjectsOfEmployee()
        {
            var tasksOfPro = await _service.GetProjectsOfEmployee();

            return tasksOfPro;
        }

        [HttpPost("Employee_CreateTask"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<ServiceResponse<string>>> Employee_CreateTask(EmployeeNewTask data)
        {
            var response = await _service.Employee_CreateTask(data);
            if (string.IsNullOrEmpty(response.Message))
            {
                return BadRequest(response);
            }
            return Ok(response);

        }


        [HttpPut("AddEmployeeToTaskAsync"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<ServiceResponse<string>>> AddEmployeeToTaskAsync(int taskId, AddTaskToEmployee data)
        {
            var response = await _service.AddEmployeeToTaskAsync(taskId, data);
            if (string.IsNullOrEmpty(response.Message))
            {
                return BadRequest(response);
            }
            return Ok(response);

        }




        [HttpPut("Mark Task As Completed Employee{id}"), Authorize(Roles = "Employee")]
        public async Task<ActionResult<ServiceResponse<string>>> MarkTaskAsCompletedEmployee(int id)
        {
            var response = await _service.MarkTaskAsCompleted(id);
            if (response.Message != "")
            {
                return BadRequest(response);
            }
            return Ok(response);
        }



    }
}
