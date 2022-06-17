using ApplicationLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUserApplicationService _application;


        public UserController(IUserApplicationService application)
        {
            _application = application;
        }


        // GET api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers([FromQuery] string? name = "")
        {
            if (string.IsNullOrEmpty(name))
                return _application.GetUsersApp();
            else
            {
                // appel new methode GetUserByName(name)

                return null;
            }
        }





        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User GetById(int id)
        {
            return null; // _application.context.Set<User>().SingleOrDefault(u => u.Id == id);
        }




        //// GET api/<UserController>/5
        //[HttpGet("{name}")]
        //public User GetByName(string name)
        //{
        //    return null; // _application.context.Set<User>().SingleOrDefault(u => u.Name == name);
        //}



        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }

}

