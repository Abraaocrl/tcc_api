using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TCC_API.Models.Auxiliar;
using TCC_API.Models.Database;
using TCC_API.Models.Extensions;

namespace TCC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult Get()
        {
            var user = _dbContext.Users.ToList();

            return Ok(user);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult Get(long id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post([FromBody] User usuario)
        {
            var usuarioExistente = _dbContext.Users.Where(x => x.Username == usuario.Username || x.Email == usuario.Email).Any();
            if (usuarioExistente)
                return BadRequest("E-mail e/ou usuário já existentes.");

            usuario.Senha = PasswordEncryption.CalculateMD5Hash(usuario.Senha);
            usuario.DataCriacao = DateTime.Now;
            usuario.DataEdicao = null;

            var resultado = _dbContext.Users.Add(usuario).Entity;
            _dbContext.SaveChanges();

            return Ok(resultado);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] User usuario)
        {
            var usuarioExistente = _dbContext.Users.Where(x => (x.Username == usuario.Username || x.Email == usuario.Email) && x.Id != id).Any();
            if (usuarioExistente)
                return BadRequest("E-mail e/ou usuário já existentes.");

            var userDb = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (userDb == null)
                return NotFound();

            userDb.Username = usuario.Username;
            userDb.Senha = PasswordEncryption.CalculateMD5Hash(usuario.Senha);
            userDb.Email = usuario.Email;
            userDb.DataEdicao = DateTime.Now;

            _dbContext.SaveChanges();

            return Ok();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return NotFound();

            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login dados)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Username == dados.usuario || x.Email == dados.usuario);

            if (user == null)
                return Unauthorized("Usuário ou e-mail inválido");

            if (user.Senha != PasswordEncryption.CalculateMD5Hash(dados.senha))
                return Unauthorized("Senha inválida");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], audience: ConfigurationManager.AppSetting["JWT:ValidAudience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(6), signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new
            {
                Token = tokenString
            });
        }
    }
}
