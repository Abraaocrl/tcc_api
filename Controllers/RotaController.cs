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
            _dbContext= dbContext;
        }

        //[HttpGet("{idCidadeOrigem}/{idCidadeDestino}")]
        //public ActionResult GetRotaDeOrigemADestino(long idCidadeOrigem, long idCidadeDestino)
        //{
        //    var rotaId = _dbContext.Rotas.FirstOrDefault(x => x.Paradas.Select(y => y.IdCidade).Contains(idCidadeOrigem) && x.Paradas.Select(y => y.IdCidade).Contains(idCidadeDestino)).Select(x => x.Id);

        //    var rotaParadaOrigem = _dbContext.RotaParadas.Include(x => x.Horarios).FirstOrDefault(x => x.IdRota == rotaId && x.IdCidade == idCidadeOrigem);
        //    var rotaParadaDestino = _dbContext.RotaParadas.Include(x => x.Horarios).FirstOrDefault(x => x.IdRota == rotaId && x.IdCidade == idCidadeDestino);

        //    return Ok(new
        //    {
        //        origem= rotaParadaOrigem,
        //        destino= rotaParadaDestino
        //    });
        //}
    }
}
