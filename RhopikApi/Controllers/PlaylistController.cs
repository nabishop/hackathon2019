using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RhopikApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace RhopikApi.Controllers
{
    [Route("api/song")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistItemContext _context;

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistItem>>> GetPlaylistItems()
        {
            return await _context.PlaylistItems.ToListAsync();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistItem>> GetPlaylistItem(long id)
        {
            var playlistItem = await _context.PlaylistItems.FindAsync(id);

            if (playlistItem == null)
            {
                return NotFound();
            }

            return playlistItem;
        }

        // POST: api/Song
        [HttpPost]
        public async Task<ActionResult<PlaylistItem>> PostPlaylistItem(PlaylistItem item)
        {
            _context.PlaylistItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPlaylistItem), new { id = item.Id }, item);
        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistItem(long id, PlaylistItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylistItem(long id)
        {
            var playlistItem = await _context.PlaylistItems.FindAsync(id);

            if (playlistItem == null)
            {
                return NotFound();
            }

            _context.PlaylistItems.Remove(playlistItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public PlaylistController(PlaylistItemContext context)
        {
            _context = context;

            if (_context.PlaylistItems.Count() == 0)
            {
                // Create a new SongItem if collection is empty,
                // which means you can't delete all SongItems.
                // _context.SongItems.Add(new SongItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }
    }
}