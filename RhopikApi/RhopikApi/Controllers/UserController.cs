using Microsoft.AspNetCore.Mvc;
using RhopikApi.Models;
using System.Collections.Generic;

namespace RhopikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserItemContext _context;

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserItem>> Get()
        {
            return _context.GetUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public UserController(UserItemContext context)
        {
            _context = context;
        }
    }
}
