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
            return Ok(taskService.GetOneTask(userId));

        }




        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskModel task) 
        {
            taskService.SaveTask(task);
            return Ok();
        }




        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TaskModel task)
        {
            taskService.UpdateTask(id, task);
            return Ok();
        }




        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            taskService.DeleteTask(id);
            return Ok();
        }
    }
}
