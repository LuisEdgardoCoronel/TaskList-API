using Microsoft.AspNetCore.Mvc;

namespace TaskList_API.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class DbConectionController:ControllerBase
    {
        TaskContext dbcontext;
        public DbConectionController(TaskContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDb()
        {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }


    }
}
