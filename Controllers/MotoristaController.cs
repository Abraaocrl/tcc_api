using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Models.Extensions;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class MotoristaController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public MotoristaController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<MotoristaController>
        [HttpGet]
        public ActionResult Get()
        {
            var user = _dbContext.Motoristas.ToList();

            return Ok(user);
        }

        // GET api/<MotoristaController>/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            try
            {
                var motorista = _dbContext.Motoristas.Include(x => x.Usuario).FirstOrDefault(x => x.Id == id);

                if (motorista == null)
                    return NotFound();

                return Ok(motorista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<MotoristaController>
        [HttpPost]
        public ActionResult Post([FromBody] Motorista motorista)
        {
            try
            {
                var motoristaExistente = _dbContext.Motoristas.Where(x => x.Documento == motorista.Documento).Any();
                if (motoristaExistente)
                    return BadRequest();

                motorista.DataNascimento = motorista.DataNascimento.Date;
                motorista.DataCriacao = DateTime.Now;
                motorista.DataEdicao = null;

                var resultado = _dbContext.Motoristas.Add(motorista).Entity;
                _dbContext.SaveChanges();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MotoristaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Motorista motorista)
        {
            try
            {
                var motoristaExistente = _dbContext.Motoristas.Where(x => (x.Nome == motorista.Documento) && x.Id != id).Any();
                if (motoristaExistente)
                    return BadRequest("Documento já cadastrado.");

                var motoristaDb = _dbContext.Motoristas.FirstOrDefault(x => x.Id == id);

                if (motoristaDb == null)
                    return NotFound("Motorista não encontrado.");

                motoristaDb.Documento = motorista.Documento;
                motoristaDb.Nome = motorista.Nome;
                motoristaDb.DataNascimento = motorista.DataNascimento.Date;
                motoristaDb.IdUsuario = motorista.IdUsuario;
                motoristaDb.DataEdicao = DateTime.Now;

                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MotoristaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var motorista = _dbContext.Motoristas.FirstOrDefault(x => x.Id == id);

                if (motorista == null)
                    return NotFound();

                _dbContext.Motoristas.Remove(motorista);
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
