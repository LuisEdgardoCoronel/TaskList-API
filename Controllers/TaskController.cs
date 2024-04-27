using Microsoft.AspNetCore.Mvc;
using TaskList_API.Model;
using TaskList_API.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }



        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(taskService.GetTasks());
        }



        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public IActionResult GetTask(Guid id)
        {
            return Ok(taskService.GetOneTask(id));
             
        }




        // GET api/<TaskController>/user/5
        [HttpGet("user/{userId}")]
        public IActionResult GetTaksByUser(Guid userId)
        {
            return Ok(taskService.GetTaskByUser(userId));

        }




        // POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDto taskdto) 
        {
            var task = new TaskModel
            {
                TaskId = taskdto.TaskId,
                UserId = taskdto.UserId,
                TaskName = taskdto.TaskName,
                TaskDescription = taskdto.TaskDescription,
                CreatedDate = DateTime.UtcNow,
                ImportanceOfTask = taskdto.ImportanceOfTask,
                
            };
            await taskService.SaveTask(task);
            return Ok();
        }




        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] TaskDto taskdto)
        {
            var task = new TaskModel
            {
                TaskName = taskdto.TaskName,
                TaskDescription = taskdto.TaskDescription,
                ImportanceOfTask = taskdto.ImportanceOfTask,

            };
            await taskService.UpdateTask(id, task);
            return Ok();
        }




        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await taskService.DeleteTask(id);
            return Ok();
        }
    }
}
