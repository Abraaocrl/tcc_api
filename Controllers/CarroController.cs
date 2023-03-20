using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Models.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CarroController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CarroController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<CarroController>
        [HttpGet]
        public ActionResult Get()
        {
            var carros = _dbContext.Carros.Include(x => x.Motorista).ToList();

            return Ok(carros);
        }

        // GET api/<CarroController>/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var carro = _dbContext.Carros.FirstOrDefault(x => x.Id == id, null);

            if (carro == null)
                return NotFound();

            return Ok(carro);
        }

        // POST api/<CarroController>
        [HttpPost]
        public ActionResult Post([FromBody] Carro carro)
        {
            var carroExistente = _dbContext.Carros.Where(x => x.Placa == carro.Placa).Any();
            if (carroExistente)
                return BadRequest("Placa já existente.");

            carro.DataCriacao = DateTime.Now;
            carro.DataEdicao = null;

            var resultado = _dbContext.Carros.Add(carro).Entity;
            _dbContext.SaveChanges();

            return Ok(resultado);
        }

        // PUT api/<CarroController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Carro carro)
        {
            var carroExistente = _dbContext.Carros.Where(x => (x.Placa == carro.Placa) && x.Id != id).Any();
            if (carroExistente)
                return BadRequest("Placa já existente.");

            var carroDb = _dbContext.Carros.FirstOrDefault(x => x.Id == id);

            if (carroDb == null)
                return NotFound();

            carroDb.Placa = carro.Placa;
            carroDb.Passageiros = carro.Passageiros;
            carroDb.IdMotorista = carro.IdMotorista;
            carroDb.DataEdicao = DateTime.Now;

            _dbContext.SaveChanges();

            return Ok();
        }

        // DELETE api/<CarroController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var carro = _dbContext.Carros.FirstOrDefault(x => x.Id == id);

            if (carro == null)
                return NotFound();

            _dbContext.Carros.Remove(carro);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
