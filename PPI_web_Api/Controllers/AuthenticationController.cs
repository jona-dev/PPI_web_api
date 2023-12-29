using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using DB.Entities;
using System.Text;
using DB;

namespace PPI_web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string SecretKey;
        private DbPPIContext _dbPPIContext;

        public AuthenticationController(IConfiguration configuration, DbPPIContext context)
        {
            SecretKey = configuration.GetSection("Settings").GetSection("secretkey").ToString();
            _dbPPIContext = context;
        }

        [HttpPost]
        [Route("Validate")]
        public IActionResult Validate([FromBody] User usuario)
        {
            var usr = _dbPPIContext.Users.FirstOrDefault( u => u.Email == usuario.Email);
            if (usr == null || usr.Password != usuario.Password)
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });
  
            var keyByte = Encoding.ASCII.GetBytes(SecretKey);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier,usuario.Email));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                                        new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenResult = tokenHandler.WriteToken(tokenConfig);

            return StatusCode(StatusCodes.Status200OK, new { token =  tokenResult});
         
        }
    }
}
