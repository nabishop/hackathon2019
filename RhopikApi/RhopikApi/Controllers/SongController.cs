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
    public class SongController : ControllerBase
    {
        private readonly SongItemContext _context;

        // GET: api/Song
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongItem>>> GetSongItems()
        {
            return _context.getAllSongs();
        }

        // GET: api/Song/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongItem>> GetSongItem(long id)
        {
            var songItem = await _context.SongItems.FindAsync(id);

            if (songItem == null)
            {
                return NotFound();
            }

            return songItem;
        }

        // POST: api/Song
        [HttpPost]
        public async Task<ActionResult<SongItem>> PostSongItem(SongItem item)
        {
            _context.SongItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSongItem), new { id = item.song_id }, item);
        }

        // PUT: api/Song/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongItem(long id, SongItem item)
        {
            if (id != item.song_id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Song/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSongItem(long id)
        {
            var songItem = await _context.SongItems.FindAsync(id);

            if (songItem == null)
            {
                return NotFound();
            }

            _context.SongItems.Remove(songItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public SongController(SongItemContext context)
        {
            _context = context;
        }
    }
}