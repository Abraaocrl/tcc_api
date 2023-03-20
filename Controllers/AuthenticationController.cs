using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Login([FromBody] Login dados)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == dados.usuario || x.Email == dados.usuario);

            if (user == null)
                return Unauthorized("Usuário ou e-mail inválido");

            if (user.Senha != PasswordEncryption.CalculateMD5Hash(dados.senha))
                return Unauthorized("Senha inválida");

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"], audience: ConfigurationManager.AppSetting["JWT:ValidAudience"], claims: new List<Claim>() { new Claim("id", user.Id.ToString()) }, expires: DateTime.Now.AddMinutes(30), signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new
            {
                Token = tokenString
            });
        }

        [HttpPost("validate")]
        public async Task<IActionResult> ValidateToken([FromBody] string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

                return Ok(new
                {
                    usuario = $"{user.Nome} {user.Sobrenome}",
                });
            }
            catch
            {
                // return null if validation fails
                return BadRequest();
            }
        }
    }
}
