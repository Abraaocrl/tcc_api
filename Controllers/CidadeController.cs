using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Get()
        {
            var cidades = _dbContext.Cidades.OrderBy(x => x.Nome).ToList().Select(x => new { x.Id, Nome = $"{x.Nome}/{x.Estado}" });

            return Ok(cidades);
        }
    }
}
