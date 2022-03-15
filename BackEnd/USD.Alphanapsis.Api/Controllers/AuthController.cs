using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Response;
using USD.Alphanapsis.Entidades;
using USD.Alphanapsis.Servicios.IRepository;

namespace USD.Alphanapsis.Api.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiAuth")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioRepository _ctRepo;
        private readonly IConfiguration _config;

        public AuthController(IUsuarioRepository ctRepo, IConfiguration config)
        {
            _ctRepo = ctRepo;
            _config = config;
        }

        /// <summary>
        /// Obtener todos los usuarios
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UsuarioDto>))]
        [ProducesResponseType(400)]
        [Route("users")]
        public IActionResult GetUsuarios()
        {
            var list = _ctRepo.GetUsuarios();
            return Ok(list);
        }

        /// <summary>
        /// Autentica los usuarios
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<LoginRsponse>))]
        [ProducesResponseType(400)]
        [Route("autenticar")]
        public IActionResult Autenticar(string username, string password, int sedeId)
        {
            var user = _ctRepo.AutenticarUsuario(username, password);

            if (user != null)
            {
                var userSede = _ctRepo.ExisteUsuarioSede(user.UsuarioId, sedeId);

                if (userSede != null)
                {
                    var usuarioDesdeRepo = new LoginRsponse()
                    {
                        UsuarioId = user.UsuarioId,
                        Nombres = user.NombreCompleto,
                        Username = user.Username,
                        TipoAtencionId = user.TipoAtencionId,
                        CentroSaludOrigenId = userSede.CentroSaludOrigenId,
                        CentroSaludAsistencialId = userSede.CentroSaludAsistencialId
                    };

                    var claims = new[]
                           {
                            new Claim(ClaimTypes.NameIdentifier, usuarioDesdeRepo.UsuarioId.ToString()),
                            new Claim(ClaimTypes.Name, usuarioDesdeRepo.Username.ToString())
                        };

                    //Generación de token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
                    var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = credenciales
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    usuarioDesdeRepo.Token = tokenHandler.WriteToken(token);
                    return Ok(usuarioDesdeRepo);
                }
                else
                    return Unauthorized();
            }
            else
                return Unauthorized();
        }
    }
}
