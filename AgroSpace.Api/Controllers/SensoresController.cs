using AgroSpace.Api.Data;
using AgroSpace.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgroSpace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensoresController : ControllerBase
    {
        private readonly AgroDbContext _context;

        public SensoresController(AgroDbContext context)
        {
            _context = context;
        }

        // GET: api/Sensores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetSensores()
        {
            return await _context.Sensores.Include(s => s.Local).ToListAsync();
        }

        // GET
        [HttpGet("{id}")]
        public async Task<ActionResult<Sensor>> GetSensor(int id)
        {
            var sensor = await _context.Sensores.Include(s => s.Local)
                                                .FirstOrDefaultAsync(s => s.IdSensor == id);

            if (sensor == null)
            {
                return NotFound("Sensor não encontrado.");
            }

            return sensor;
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<Sensor>> PostSensor(Sensor sensor)
        {
            // Validação
            var localExiste = await _context.Locais.AnyAsync(l => l.IdLocal == sensor.IdLocal);
            if (!localExiste)
            {
                return BadRequest("Não é possível cadastrar o sensor: O Local informado não existe.");
            }

            _context.Sensores.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSensor), new { id = sensor.IdSensor }, sensor);
        }

        // PUT
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, Sensor sensor)
        {
            if (id != sensor.IdSensor)
            {
                return BadRequest("O ID da URL não corresponde ao ID do objeto.");
            }

            // Validação
            var localExiste = await _context.Locais.AnyAsync(l => l.IdLocal == sensor.IdLocal);
            if (!localExiste)
            {
                return BadRequest("Não é possível atualizar: O Local informado não existe.");
            }

            _context.Entry(sensor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorExists(id))
                {
                    return NotFound("Sensor não encontrado para atualização.");
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
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var sensor = await _context.Sensores.FindAsync(id);
            if (sensor == null)
            {
                return NotFound("Sensor não encontrado para exclusão.");
            }

            _context.Sensores.Remove(sensor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SensorExists(int id)
        {
            return _context.Sensores.Any(e => e.IdSensor == id);
        }
    }
}