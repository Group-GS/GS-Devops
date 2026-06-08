using AgroSpace.Api.Data;
using AgroSpace.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroSpace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocaisController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public LocaisController(AgroDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Local>>> GetLocais()
        {
            return await _context.Locais.Include(l => l.Sensores).ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Local>> GetLocal(int id)
        {
            var local = await _context.Locais.Include(l => l.Sensores)
                                             .FirstOrDefaultAsync(l => l.IdLocal == id);

            if (local == null)
            {
                return NotFound("Local não encontrado."); // Tratamento de entrada inválida
            }

            return local;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Local>> PostLocal(Local local)
        {
            _context.Locais.Add(local);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLocal), new { id = local.IdLocal }, local);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocal(int id, Local local)
        {
            if (id != local.IdLocal)
            {
                return BadRequest("O ID da URL não corresponde ao ID do objeto.");
            }

            _context.Entry(local).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalExists(id))
                {
                    return NotFound("Local não encontrado para atualização.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocal(int id)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local == null)
            {
                return NotFound("Local não encontrado para exclusão.");
            }

            _context.Locais.Remove(local);
            await _context.SaveChangesAsync(); // Se deletar o local, os sensores vinculados também serão deletados (Cascade)

            return NoContent();
        }

        private bool LocalExists(int id)
        {
            return _context.Locais.Any(e => e.IdLocal == id);
        }
    }
}