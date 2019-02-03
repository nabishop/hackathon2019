using Microsoft.AspNetCore.Mvc;
using RhopikApi.Models;
using System.Collections.Generic;

namespace RhopikApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserItemContext _context;

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserItem>> GetAllUsers()
        {
            return _context.GetUsers();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public UserItem GetUserWithId(int id)
        {
            return _context.GetUserWithId(id);
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
