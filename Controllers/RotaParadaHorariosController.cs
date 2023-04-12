using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class RotaParadaHorariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RotaParadaHorariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RotaParadaHorarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RotaParadaHorario>>> GetRotaParadaHorarios()
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }
            return await _context.RotaParadaHorarios.ToListAsync();
        }

        // GET: api/RotaParadaHorarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RotaParadaHorario>> GetRotaParadaHorario(long id)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }
            var rotaParadaHorario = await _context.RotaParadaHorarios.FindAsync(id);

            if (rotaParadaHorario == null)
            {
                return NotFound();
            }

            return rotaParadaHorario;
        }

        // GET: api/RotaParadaHorarios/Parada/5
        [HttpGet("Parada/{id}")]
        public async Task<ActionResult<List<RotaParadaHorario>>> GetHorariosParada(long idRotaParada)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }
            var rotaParadaHorario = await _context.RotaParadaHorarios.Where(x => x.IdRotaParada == idRotaParada).ToListAsync();

            if (rotaParadaHorario == null)
            {
                return NotFound();
            }

            return Ok(rotaParadaHorario);
        }

        // PUT: api/RotaParadaHorarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRotaParadaHorario(long id, RotaParadaHorario rotaParadaHorario)
        {
            if (id != rotaParadaHorario.Id)
            {
                return BadRequest();
            }

            rotaParadaHorario.Horario = new DateTime(1, 1, 1, rotaParadaHorario.Horario.Hour, rotaParadaHorario.Horario.Minute, rotaParadaHorario.Horario.Second);
            _context.Entry(rotaParadaHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RotaParadaHorarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RotaParadaHorarios
        [HttpPost]
        public async Task<ActionResult<RotaParadaHorario>> PostRotaParadaHorario(RotaParadaHorario rotaParadaHorario)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return Problem("Entity set 'AppDbContext.RotaParadaHorarios'  is null.");
            }

            rotaParadaHorario.Horario = new DateTime(1, 1, 1, rotaParadaHorario.Horario.Hour, rotaParadaHorario.Horario.Minute, rotaParadaHorario.Horario.Second);

            if (HorarioJaExisteNaParada(rotaParadaHorario.Horario, rotaParadaHorario.IdRotaParada))
            {
                return BadRequest("Horário já cadastrado previamente na parada");
            }

            _context.RotaParadaHorarios.Add(rotaParadaHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRotaParadaHorario", new { id = rotaParadaHorario.Id }, rotaParadaHorario);
        }

        // DELETE: api/RotaParadaHorarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRotaParadaHorario(long id)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }
            var rotaParadaHorario = await _context.RotaParadaHorarios.FindAsync(id);
            if (rotaParadaHorario == null)
            {
                return NotFound();
            }

            _context.RotaParadaHorarios.Remove(rotaParadaHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaParadaHorarioExists(long id)
        {
            return (_context.RotaParadaHorarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool HorarioJaExisteNaParada(DateTime horario, long idParada)
        {
            return (_context.RotaParadaHorarios?.Any(e => e.IdRotaParada == idParada && e.Horario.TimeOfDay == horario.TimeOfDay)).GetValueOrDefault();
        }
    }
}
