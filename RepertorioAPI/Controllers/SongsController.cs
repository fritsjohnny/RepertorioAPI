using Microsoft.AspNetCore.Mvc;
using RepertorioAPI.Models;
using RepertorioAPI.Services;

namespace RepertorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return Ok(await _songService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(int id)
        {
            Song? song = await _songService.GetByIdAsync(id);

            if (song == null)
                return NotFound();

            return Ok(song);
        }

        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            Song? created = await _songService.CreateAsync(song);

            return CreatedAtAction(nameof(GetSong), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, Song song)
        {
            if (id != song.Id)
                return BadRequest();

            bool updated = await _songService.UpdateAsync(song);

            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            bool deleted = await _songService.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Song>>> SearchSongs([FromQuery] string? title, [FromQuery] string? theme, [FromQuery] string? tags)
        {
            List<Song>? result = await _songService.SearchAsync(title, theme, tags);

            return Ok(result);
        }
    }
}
