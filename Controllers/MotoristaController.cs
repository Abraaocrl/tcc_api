using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCC_API.Models.Database;
using TCC_API.Models.Extensions;
using TCC_API.Services;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class MotoristaController : ControllerBase
    {
        private readonly MotoristaService _motoristaService;

        public MotoristaController(MotoristaService motoristaService)
        {
            _motoristaService = motoristaService;
        }

        // GET: api/<MotoristaController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var motoristas = await _motoristaService.Get();

            return Ok(motoristas);
        }

        // GET api/<MotoristaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var motorista = await _motoristaService.GetById(id);

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
        public async Task<ActionResult> Post([FromBody] Motorista motorista)
        {
            try
            {
                var result = await _motoristaService.Create(motorista);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MotoristaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Motorista motorista)
        {
            try
            {
                var result = await _motoristaService.Update(motorista);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MotoristaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _motoristaService.Delete(id);

                if (!result)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
