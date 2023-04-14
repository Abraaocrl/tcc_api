using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;

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

        [HttpGet("{idCidadeOrigem}/{idCidadeDestino}")]
        public async Task<IActionResult> GetRotaDeOrigemADestino(long idCidadeOrigem, long idCidadeDestino)
        {
            var idParadas = _dbContext.Rotas.Include(x => x.Paradas).Where(x => x.Paradas.Any(y => idCidadeDestino == y.IdCidade) && x.Paradas.Any(y => idCidadeOrigem == y.IdCidade)).SelectMany(x => x.Paradas).Select(x => x.Id);
            var horarios = await _dbContext.RotaParadaHorarios.AsNoTracking().Include(x => x.RotaParada).ThenInclude(x => x.Cidade).Where(x => idParadas.Contains(x.IdRotaParada)).OrderBy(x => x.Horario).ToListAsync();
            var horariosDiretos = horarios.Where(x => x.RotaParada.IdCidade == idCidadeOrigem || x.RotaParada.IdCidade == idCidadeDestino).OrderBy(x => x.Horario).ToList();

            return Ok(new
            {
                RotaCompleta = horarios,
                RotaDireta = horariosDiretos
            });
        }

        [HttpPost]
        public IActionResult Create(Rota rota)
        {
            try
            {
                var rotaExistente = _dbContext.Rotas.Any(x => x.IdCarro == rota.IdCarro && x.IdRotaParadaDestino == rota.IdRotaParadaDestino && x.IdRotaParadaOrigem == rota.IdRotaParadaOrigem);
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
    }
}
