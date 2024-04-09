using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get(Guid id)
        {
            var taskSearched = taskService.GetTasks();
            return ;
        }

        // POST api/<TaskController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
