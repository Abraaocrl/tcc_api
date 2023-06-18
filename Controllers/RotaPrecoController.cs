using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Models.DTO;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class RotaPrecoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RotaPrecoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/<RotaPrecoController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rotaPrecos = _context.RotaPrecos.ToList();

                return Ok(rotaPrecos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<RotaPrecoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var rotaPreco = _context.RotaPrecos.FirstOrDefault(x => x.Id == id);
                if (rotaPreco == null)
                {
                    return NotFound();
                }


                return Ok(rotaPreco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<RotaPrecoController>/5
        [HttpGet("Rota/{idRota}")]
        public async Task<ActionResult<IEnumerable<RotaPrecoDTO>>> GetByRota(long idRota)
        {
            try
            {
                var rotaPreco = await _context.RotaPrecos
                    .Where(p => p.IdRota == idRota)
                    .OrderBy(p => p.IdRotaParadaOrigem)
                    .ThenBy(p => p.IdRotaParadaDestino)
                    .Select(x => new RotaPrecoDTO()
                    {
                        IdRota = x.IdRota,
                        IdRotaParadaOrigem = x.IdRotaParadaOrigem ?? 0,
                        IdRotaParadaDestino = x.IdRotaParadaDestino ?? 0,
                        Preco = x.Preco.ToString("C"),
                        Distancia = x.Distancia.ToString("G"),
                    })
                    .ToListAsync();


                return Ok(rotaPreco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RotaPrecoController>
        [HttpPost]
        public IActionResult Post([FromBody] RotaPreco rotaPreco)
        {
            try
            {
                VerificarExistenciaPrecoPost(rotaPreco);

                rotaPreco.DataCriacao = DateTime.Now;
                rotaPreco.DataEdicao = null;

                var resultado = _context.RotaPrecos.Add(rotaPreco).Entity;
                _context.SaveChanges();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void VerificarExistenciaPrecoPost(RotaPreco rotaPreco)
        {
            var precoExistente = _context.RotaPrecos.FirstOrDefault(x => x.IdRota == rotaPreco.IdRota &&
                                                                        x.IdRotaParadaOrigem == rotaPreco.IdRotaParadaOrigem &&
                                                                        x.IdRotaParadaDestino == rotaPreco.IdRotaParadaDestino);
            if (precoExistente != null)
                throw new Exception("Preço já cadastrado para parte da rota em questão.");
        }

        // PUT api/<RotaPrecoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] RotaPreco rotaPreco)
        {
            try
            {
                VerificarExistenciaPrecoPut(rotaPreco);

                var rotaPrecoDb = _context.RotaPrecos.FirstOrDefault(x => x.Id == id);
                if (rotaPrecoDb == null)
                    return NotFound("Preço de passagem não encontrado.");

                rotaPrecoDb.IdRota = rotaPreco.IdRota;
                rotaPrecoDb.IdRotaParadaDestino = rotaPreco.IdRotaParadaDestino;
                rotaPrecoDb.IdRotaParadaOrigem = rotaPreco.IdRotaParadaOrigem;
                rotaPrecoDb.Preco = rotaPreco.Preco;
                rotaPrecoDb.DataEdicao = DateTime.Now;

                _context.SaveChanges();

                return Ok(rotaPrecoDb);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private void VerificarExistenciaPrecoPut(RotaPreco rotaPreco)
        {
            var precoExistente = _context.RotaPrecos.FirstOrDefault(x => x.IdRota == rotaPreco.IdRota &&
                                                                                        x.IdRotaParadaOrigem == rotaPreco.IdRotaParadaOrigem &&
                                                                                        x.IdRotaParadaDestino == rotaPreco.IdRotaParadaDestino &&
                                                                                        x.Preco == rotaPreco.Preco);
            if (precoExistente != null)
                throw new Exception("Preço já cadastrado para parte da rota selecionada.");
        }

        // DELETE api/<RotaPrecoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var rotaPrecoDb = _context.RotaPrecos.FirstOrDefault(x => x.Id == id);
                if (rotaPrecoDb == null)
                    return NotFound("Preço da passagem não encontrado.");

                _context.RotaPrecos.Remove(rotaPrecoDb);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
