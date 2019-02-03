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
        public ActionResult<IEnumerable<PlaylistItem>> GetPlaylistsWithUserId(int id)
        {
            return _context.GetPlaylistsWithUserID(id);
        }

        // POST: api/Playlist
        [HttpPost]
        public void Post(PlaylistItem value)
        {
            _context.PostPlaylist(value);
        }

        // PUT: api/Playlist/5
        [HttpPut("{id}")]
        public void PutPlaylistName(int userId, string oldName, string newName)
        {
            _context.PutPlaylistName(userId, oldName, newName);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int userId, string playlistName)
        {
            _context.DeletePlaylist(playlistName, userId);
        }

        public PlaylistController(PlaylistItemContext context)
        {
            _context = context;
        }
    }
}
