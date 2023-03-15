using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public AuthenticationController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
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
