using Microsoft.AspNetCore.Mvc;
using RepertorioAPI.Models;
using RepertorioAPI.Services;

namespace RepertorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepertoiresController : ControllerBase
    {
        private readonly IRepertoireService _repertoireService;

        public RepertoiresController(IRepertoireService repertoireService)
        {
            _repertoireService = repertoireService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repertoire>>> GetRepertoires()
        {
            return Ok(await _repertoireService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Repertoire>> GetRepertoire(int id)
        {
            Repertoire? rep = await _repertoireService.GetByIdAsync(id);

            return rep == null ? NotFound() : Ok(rep);
        }

        [HttpPost]
        public async Task<ActionResult<Repertoire>> PostRepertoire(Repertoire repertoire)
        {
            Repertoire? created = await _repertoireService.CreateAsync(repertoire);

            return CreatedAtAction(nameof(GetRepertoire), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepertoire(int id, Repertoire repertoire)
        {
            if (id != repertoire.Id)
                return BadRequest();

            bool updated = await _repertoireService.UpdateAsync(repertoire);

            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepertoire(int id)
        {
            bool deleted = await _repertoireService.DeleteAsync(id);

            return deleted ? NoContent() : NotFound();
        }
    }
}
