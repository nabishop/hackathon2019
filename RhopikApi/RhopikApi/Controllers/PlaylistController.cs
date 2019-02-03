using Microsoft.AspNetCore.Mvc;
using RhopikApi.Models;
using System.Collections.Generic;

namespace RhopikApi.Controllers
{
    [Route("api/playlist")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistItemContext _context;

        // GET: api/Playlist
        [HttpGet]
        public ActionResult<IEnumerable<PlaylistItem>> GetAllPlaylists()
        {
            return _context.GetPlaylists();
        }

        // GET: api/Playlist/5
        [HttpGet("{id}")]
        public string GetPlaylistWithId(int id)
        {
            return "value";
        }

        // POST: api/Playlist
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Playlist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public PlaylistController(PlaylistItemContext context)
        {
            _context = context;
        }
    }
}
