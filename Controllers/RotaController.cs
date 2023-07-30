using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;
using System.Transactions;
using TCC_API.Models.Database;
using TCC_API.Models.DTO;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : Controller
    {
        private AppDbContext _dbContext;

        public RotaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var resultado = await _dbContext.RotaParadas.Include(x => x.Rota).Include(x => x.Cidade).GroupBy(p => p.IdRota).Select(x => new RotaListItemDTO()
                {
                    Id = x.Key ?? 0,
                    Inicio = x.FirstOrDefault(y => y.Rota.IdRotaParadaOrigem == y.Id).Cidade.Nome,
                    Fim = x.FirstOrDefault(y => y.Rota.IdRotaParadaDestino == y.Id).Cidade.Nome,
                }).OrderBy(r => r.Id).ToListAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Contagem")]
        [Authorize]
        public async Task<IActionResult> GetCount()
        {
            try
            {
                var resultado = await _dbContext.Rotas.CountAsync();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                Rota? rota = await GetRota(id);

                if (rota == null)
                    return NotFound("Rota não encontrada");

                return Ok(rota);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private async Task<Rota> GetRota(long id)
        {
            return await _dbContext.Rotas.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        [HttpGet("{idCidadeOrigem}/{idCidadeDestino}")]
        public async Task<IActionResult> GetRotaDeOrigemADestino(long idCidadeOrigem, long idCidadeDestino)
        {
            try
            {
                var idParadas = _dbContext.Rotas.Include(x => x.Paradas).Where(x => x.Paradas.Any(y => idCidadeDestino == y.IdCidade) && x.Paradas.Any(y => idCidadeOrigem == y.IdCidade)).SelectMany(x => x.Paradas).Select(x => x.Id).ToList();
                var rotas = _dbContext.RotaParadaHorarios
                    .Include(x => x.RotaParada)
                    .ThenInclude(x => x.Cidade)
                    .AsEnumerable()
                    .Where(x => idParadas.Contains(x.IdRotaParada))
                    .GroupBy(x => x.RotaParada.IdRota).ToList();


                var dadosRotas = new List<object>();

                foreach (var rota in rotas)
                {
                    var horariosDiretos = rota.Where(x => x.RotaParada.IdCidade == idCidadeOrigem || x.RotaParada.IdCidade == idCidadeDestino).OrderBy(x => x.Horario).ThenBy(x => x.RotaParada.IdRota).ToList();
                    var rotaCompleta = rota.Where(x => x.RotaParada.IdCidade != null && x.RotaParada.IdCidade != null).OrderBy(x => x.Horario).ThenBy(x => x.RotaParada.IdRota).ToList();

                    dadosRotas.Add(new
                    {
                        RotaDireta = horariosDiretos
                    });
                }

                return Ok(dadosRotas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Rota rota)
        {
            try
            {
                var rotaExistente = _dbContext.Rotas.Any(x => x.IdRotaParadaOrigem == rota.IdRotaParadaOrigem);
                if (rotaExistente)
                {
                    throw new Exception("Rota já cadastrada para trajeto selecionado.");
                }

                var rotaDb = _dbContext.Rotas.Add(rota);
                _dbContext.SaveChanges();

                return Ok(rota);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{idCidade}")]
        [Authorize]
        public IActionResult CreateRota(RotaParada paradaInicial)
        {
            try
            {
                using(var transaction = _dbContext.Database.BeginTransaction())
                {
                    paradaInicial.DataCriacao = DateTime.Now;

                    paradaInicial = _dbContext.RotaParadas.Add(paradaInicial).Entity;

                    _dbContext.SaveChanges();

                    var rota = new Rota()
                    {
                        IdRotaParadaOrigem = paradaInicial.Id,
                        DataCriacao = DateTime.Now
                    };

                    rota = _dbContext.Rotas.Add(rota).Entity;

                    _dbContext.SaveChanges();

                    paradaInicial.IdRota = rota.Id;

                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return Ok(rota.Id);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("setParadaInicial/{idParada}/{idRota}")]
        [Authorize]
        public async Task<IActionResult> SetParadaInicial(long idParada, long idRota)
        {
            try
            {
                var rota = await GetRota(idRota);
                if(rota == null)
                    return NotFound("Rota não encontrada");

                var parada = await _dbContext.RotaParadas.FirstOrDefaultAsync(p => p.Id == idParada);
                if (parada == null)
                    return NotFound("Parada não encontrada");

                if(parada.IdRota != idRota)
                {
                    return BadRequest("Parada não pertence a rota indicada");
                }

                rota.IdRotaParadaOrigem = idParada;
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("setParadaFinal/{idParada}/{idRota}")]
        [Authorize]
        public async Task<IActionResult> SetParadaFinal(long idParada, long idRota)
        {
            try
            {
                var rota = await GetRota(idRota);
                if (rota == null)
                    return NotFound("Rota não encontrada");

                var parada = await _dbContext.RotaParadas.FirstOrDefaultAsync(p => p.Id == idParada);
                if (parada == null)
                    return NotFound("Parada não encontrada");

                if (parada.IdRota != idRota)
                {
                    return BadRequest("Parada não pertence a rota indicada");
                }

                rota.IdRotaParadaDestino = idParada;
                await _dbContext.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var rota = await GetRota(id);

                if (rota == null)
                {
                    return NotFound();
                }

                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        var paradas = _dbContext.RotaParadas.Where(x => x.IdRota == id).ToList();
                        var idsParadas = paradas.Select(x => x.Id).ToList();
                        var horarios = _dbContext.RotaParadaHorarios.Where(p => idsParadas.Contains(p.IdRotaParada));
                        var precos = _dbContext.RotaPrecos.Where(p => idsParadas.Contains(p.IdRotaParadaOrigem ?? 0) || idsParadas.Contains(p.IdRotaParadaDestino ?? 0));

                        _dbContext.RotaPrecos.RemoveRange(precos);
                        _dbContext.RotaParadaHorarios.RemoveRange(horarios);
                        _dbContext.RotaParadas.RemoveRange(paradas);
                        _dbContext.Rotas.Remove(rota);

                        await _dbContext.SaveChangesAsync();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return BadRequest(ex.Message);
                    }
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
