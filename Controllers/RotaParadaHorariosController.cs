using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
        [HttpGet("Parada/{idRotaParada}")]
        public async Task<ActionResult<List<RotaParadaHorario>>> GetHorariosParada(long idRotaParada)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }
            var rotaParadaHorario = await _context.RotaParadaHorarios.Where(x => x.IdRotaParada == idRotaParada).OrderBy(x => x.Horario).ToListAsync();

            if (rotaParadaHorario == null)
            {
                return NotFound();
            }

            return Ok(rotaParadaHorario);
        }

        // GET: api/RotaParadaHorarios/Parada/5
        [HttpGet("Rota/{idRota}")]
        public async Task<IActionResult> GetHorariosRota(long idRota)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }

            var idsParadas = await _context.RotaParadas.Where(x => x.IdRota == idRota).Select(x => x.Id).ToListAsync();

            var horarios = _context.RotaParadaHorarios.Where(x => idsParadas.Contains(x.IdRotaParada)).OrderBy(h => h.Horario).ToList().GroupBy(x => x.IdRotaParada);

            if (horarios == null)
            {
                return NotFound();
            }

            return Ok(horarios);
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

        [HttpPost("multiplas")]
        public async Task<IActionResult> PostMultiplasRotaParadaHorario(List<RotaParadaHorario> rotaParadaHorario)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    foreach (var horario in rotaParadaHorario)
                    {
                        var createdRota = await this.PostRotaParadaHorario(horario);
                    }

                    transaction.Commit();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        // DELETE: api/RotaParadaHorarios/5
        [HttpDelete("RotaParada/{idRotaParada}")]
        public async Task<IActionResult> DeleteRotaParadaHorarioDaRota(long idRotaParada)
        {
            if (_context.RotaParadaHorarios == null)
            {
                return NotFound();
            }
            var rotaParadaHorarios = await _context.RotaParadaHorarios.Where(h => h.IdRotaParada == idRotaParada).ToListAsync();
            if (rotaParadaHorarios == null)
            {
                return NotFound();
            }

            _context.RotaParadaHorarios.RemoveRange(rotaParadaHorarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RotaParadaHorarioExists(long id)
        {
            return (_context.RotaParadaHorarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private bool HorarioJaExisteNaParada(DateTime horario, long idParada)
        {
            return (_context.RotaParadaHorarios?.Any(e => e.IdRotaParada == idParada && e.Horario == horario)).GetValueOrDefault();
        }
    }
}
