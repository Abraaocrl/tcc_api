using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCC_API.Models.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class RotaParadaController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public RotaParadaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<RotaParadaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var rotaParadas = _dbContext.RotaParadas.ToList();

                return Ok(rotaParadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<RotaParadaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var rotaParada = _dbContext.RotaParadas.FirstOrDefault(x => x.Id == id);
                if (rotaParada == null)
                {
                    return NotFound();
                }


                return Ok(rotaParada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RotaParadaController>
        [HttpPost]
        public IActionResult Post([FromBody] RotaParada rotaParada)
        {
            try
            {
                var paradaExistente = _dbContext.RotaParadas.FirstOrDefault(x => (x.Latitude == rotaParada.Latitude && x.Longitude == rotaParada.Longitude && x.IdRota == rotaParada.IdRota) && x.Id != rotaParada.Id);
                if (paradaExistente != null)
                    throw new Exception("Parada já cadastrada na localização para a rota.");

                rotaParada.DataCriacao = DateTime.Now;
                rotaParada.DataEdicao = null;

                var resultado = _dbContext.RotaParadas.Add(rotaParada).Entity;
                _dbContext.SaveChanges();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RotaParadaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] RotaParada rotaParada)
        {
            try
            {
                var paradaExistente = _dbContext.RotaParadas.FirstOrDefault(x => (x.Latitude == rotaParada.Latitude && x.Longitude == rotaParada.Longitude && x.IdRota == rotaParada.IdRota) && x.Id != id);
                if (paradaExistente != null)
                    throw new Exception("Parada já cadastrada na localização para a rota.");

                var rotaParadaDb = _dbContext.RotaParadas.FirstOrDefault(x => x.Id == id);
                if (rotaParadaDb == null)
                    return NotFound("Parada não encontrada.");

                rotaParadaDb.IdCidade = rotaParada.IdCidade;
                rotaParadaDb.Latitude = rotaParada.Latitude;
                rotaParadaDb.Longitude = rotaParada.Longitude;
                rotaParadaDb.DataEdicao = DateTime.Now;

                _dbContext.SaveChanges();

                return Ok(rotaParadaDb);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RotaParadaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                var rotaParadaDb = _dbContext.RotaParadas.FirstOrDefault(x => x.Id == id);
                if (rotaParadaDb == null)
                    return NotFound("Parada não encontrada.");

                _dbContext.RotaParadas.Remove(rotaParadaDb);
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
