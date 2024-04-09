using Microsoft.AspNetCore.Mvc;
using TaskList_API.Model;
using TaskList_API.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskList_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService UserService;

        public UserController(IUserService service)
        {
            this.UserService = service;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(UserService.GetUsers());
        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(UserService.GetOneUser(id));
        }



        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            UserService.SaveUser(user);
            return Ok();
        }



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put( Guid id, [FromBody] UserModel user)
        {
            UserService.UpdateUser(id, user);
            return Ok();
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            UserService.DeleteUser(id);
            return Ok();
        }
    }
}
