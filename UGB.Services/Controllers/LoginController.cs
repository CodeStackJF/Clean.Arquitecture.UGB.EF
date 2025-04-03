using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UGB.Application.DTO;
using UGB.Application.Exceptions;
using UGB.Application.Helper;
using UGB.Domain.Entities;
using UGB.Domain.Interfaces;
using UGB.Services.Helper;

namespace UGB.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsersRepository usersRepository;
        private readonly IConfiguration configuration;
        public LoginController(IUsersRepository _usersRepository, IConfiguration _configuration)
        {
            usersRepository = _usersRepository;
            configuration = _configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserDTO credentials)
        {
            if(!await usersRepository.Exists(credentials.username))
            {
                throw new NotFoundException("Usuario no encontrado o no se encuentra activo.");
            }

            users user = await usersRepository.Get(credentials.username);
            if(!HashHelper.CheckHash(credentials.password, user.password, user.salt))
            {
                throw new BadHttpRequestException("Usuario o contraseña no válida.");
            }

            string secretKey = configuration.GetValue<string>("TOKEN_KEY")!;
            byte[] bytesKey = Encoding.ASCII.GetBytes(secretKey);

            ClaimsIdentity claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.username));
            claims.AddClaim(new Claim("Age", user.edad.ToString()));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytesKey), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken createdToken = tokenHandler.CreateToken(tokenDescriptor);
            string bearerToken = tokenHandler.WriteToken(createdToken);

            return Ok(new {
                user.username,
                token = bearerToken
            });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LoginData()
        {
            return Ok(new {
                user = User.GetProperty(ClaimTypes.NameIdentifier),
                age = User.GetProperty("Age", typeof(int))
            });
        }
    }
}