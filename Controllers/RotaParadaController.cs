using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TCC_API.Models.Database;
using TCC_API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class RotaParadaController : ControllerBase
    {
        private readonly IServiceBase<RotaParada> _rotaParadaService;

        public RotaParadaController(IServiceBase<RotaParada> rotaParadaService)
        {
            _rotaParadaService = rotaParadaService;
        }

        // GET: api/<RotaParadaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var rotaParadas = await _rotaParadaService.Get();

                return Ok(rotaParadas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<RotaParadaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var rotaParada = await _rotaParadaService.GetById(id);
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
        public async Task<IActionResult> Post([FromBody] RotaParada rotaParada)
        {
            try
            {
                var resultado = await _rotaParadaService.Create(rotaParada);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RotaParadaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] RotaParada rotaParada)
        {
            try
            {
                var resultado = await _rotaParadaService.Update(rotaParada);

                return Ok(resultado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RotaParadaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _rotaParadaService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
