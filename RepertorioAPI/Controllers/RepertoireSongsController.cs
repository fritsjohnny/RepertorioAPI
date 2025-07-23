using Microsoft.AspNetCore.Mvc;
using RepertorioAPI.Models;
using RepertorioAPI.Services;

namespace RepertorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepertoireSongsController : ControllerBase
    {
        private readonly IRepertoireSongService _service;

        public RepertoireSongsController(IRepertoireSongService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepertoireSong>>> GetRepertoireSongs()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RepertoireSong>> GetRepertoireSong(int id)
        {
            RepertoireSong? item = await _service.GetByIdAsync(id);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<RepertoireSong>> PostRepertoireSong(RepertoireSong repertoireSong)
        {
            RepertoireSong? created = await _service.CreateAsync(repertoireSong);

            return CreatedAtAction(nameof(GetRepertoireSong), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepertoireSong(int id, RepertoireSong repertoireSong)
        {
            if (id != repertoireSong.Id)
                return BadRequest();

            bool updated = await _service.UpdateAsync(repertoireSong);

            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepertoireSong(int id)
        {
            bool deleted = await _service.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
