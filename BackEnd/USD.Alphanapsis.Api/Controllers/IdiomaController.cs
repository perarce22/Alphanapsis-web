using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USD.Alphanapsis.Dto;
using USD.Alphanapsis.Dto.Custom;
using USD.Alphanapsis.Servicios.IRepository;

namespace USD.Alphanapsis.Api.Controllers
{
    [Authorize]
    [Route("api/language")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "ApiIdioma")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class IdiomaController : ControllerBase
    {

        private readonly IContenidoRepository _ctRepo;
        private readonly IConfiguration _config;

        public IdiomaController(IContenidoRepository ctRepo, IConfiguration config)
        {
            _ctRepo = ctRepo;
            _config = config;
        }

        /// <summary>
        /// Obtener todos los contenidos por idioma
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<TraduccionDto>))]
        [ProducesResponseType(400)]
        [Route("index")]
        public IActionResult GetLanguaje(string idioma)
        {
            var list = _ctRepo.ListarTraduccion(idioma);
            return Ok(list);
        }
    }
}
