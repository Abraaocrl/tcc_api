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
        public async Task<IActionResult> Get()
        {
            try
            {
                var rotas = await _dbContext.Rotas.Where(r => r.Paradas.Any()).ToListAsync();

                var resultado = rotas.Select(r => new RotaListItemDTO()
                {
                    Id = r.Id,
                    Inicio = r.Paradas.FirstOrDefault(p => p.Id == r.IdRotaParadaOrigem).Cidade.Nome,
                    Fim = r.Paradas.FirstOrDefault(p => p.Id == r.IdRotaParadaDestino).Cidade.Nome,
                });

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("id")]
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
                    var horariosDiretos = rota.Where(x => x.RotaParada.IdCidade == idCidadeOrigem || x.RotaParada.IdCidade == idCidadeDestino).OrderBy(x => x.RotaParada.IdRota).ThenBy(x => x.Horario).ToList();

                    dadosRotas.Add(new
                    {
                        RotaCompleta = rota,
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
        public IActionResult Create(Rota rota)
        {
            try
            {
                var rotaExistente = _dbContext.Rotas.Any(x => x.IdRotaParadaOrigem == rota.IdRotaParadaOrigem);
                if (rotaExistente)
                {
                    throw new Exception("Rota já cadastrada para trajeto e carro selecionados.");
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

        [HttpDelete]
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
                        var idsParadas = rota.Paradas.Select(p => p.Id);
                        var horarios = _dbContext.RotaParadaHorarios.Where(p => idsParadas.Contains(p.IdRotaParada));
                        var precos = _dbContext.RotaPrecos.Where(p => idsParadas.Contains(p.IdRotaParadaOrigem ?? 0) || idsParadas.Contains(p.IdRotaParadaDestino ?? 0));

                        _dbContext.RotaPrecos.RemoveRange(precos);
                        _dbContext.RotaParadaHorarios.RemoveRange(horarios);
                        _dbContext.RotaParadas.RemoveRange(rota.Paradas);
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
