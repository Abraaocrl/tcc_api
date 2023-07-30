using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CidadeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var idCidadesEmRotas = await _dbContext.RotaParadas.Select(x => x.IdCidade).Distinct().ToListAsync();
            var cidades = await _dbContext.Cidades.Where(x => idCidadesEmRotas.Contains(x.Id)).OrderBy(x => x.Nome).Select(x => new { x.Id, Nome = $"{x.Nome}/{x.Estado}" }).ToListAsync();

            return Ok(cidades);
        }

        [HttpGet("possuiCidade/{id}")]
        public async Task<IActionResult> GetCidadesLigadasPorRotaAsync(int id)
        {
            var idRotasComCidade = await _dbContext.RotaParadas.Where(x => x.IdCidade == id).Select(x => x.IdRota).Distinct().ToListAsync();
            var idCidadesAdjacentes = await _dbContext.RotaParadas.Where(x => idRotasComCidade.Contains(x.IdRota) && x.IdCidade != id).Select(x => x.IdCidade).Distinct().ToListAsync();
            var cidadesAdjacentes = await _dbContext.Cidades.Where(x => idCidadesAdjacentes.Contains(x.Id)).OrderBy(x => x.Nome).Select(x => new { x.Id, Nome = $"{x.Nome}/{x.Estado}" }).ToListAsync();

            return Ok(cidadesAdjacentes);
        }
    }
}
