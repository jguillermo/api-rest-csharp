using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace application.ApiRest.User
{
    [Route("v1/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var user = new Context.User.Domain.User {Id = "123"};
            return new string[] {user.Id, "valor2"};
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var user = new Context.User.Domain.User {Id = "123"};
            return user.Id;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}