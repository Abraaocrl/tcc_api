using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Models.Extensions;
using TCC_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CarroController : ControllerBase
    {
        private readonly CarroService _service;

        public CarroController(CarroService service)
        {
            _service = service;
        }

        // GET: api/<CarroController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var carros = await _service.Get();

            return Ok(carros);
        }

        // GET api/<CarroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var carro = await _service.GetById(id);

                return Ok(carro);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST api/<CarroController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Carro carro)
        {
            try
            {
                var carroCriado = await _service.Create(carro);

                return Ok(carro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CarroController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Carro carro)
        {
            try
            {
                carro = await _service.Update(carro);

                return Ok(carro);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CarroController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deletado = await _service.Delete(id);

                if (deletado)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
