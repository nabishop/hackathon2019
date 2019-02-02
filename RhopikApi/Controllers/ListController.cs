using Microsoft.AspNetCore.Mvc;
using RhopikApi.Models;
using System.Collections.Generic;

namespace RhopikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        // GET api/list
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/list/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/list
        [HttpPost]
        public void Post([FromBody] PlaylistItem value)
        {
            PlaylistPersistence persistence = new PlaylistPersistence();

            long id = persistence.savePlaylist(value);
        }

        // PUT api/list/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/list/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
