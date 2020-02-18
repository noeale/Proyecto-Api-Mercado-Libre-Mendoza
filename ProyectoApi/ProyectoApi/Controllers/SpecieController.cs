using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoApi.Aplicacion.Contratos.Servicios;
using ProyectoApi.WebApi.Mappers;
using ProyectoApi.WebApi.ViewModels;

namespace ProyectoApi.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    /// <summary>
    /// Servicios Rest de la Api donde permite conocer si es un humano o mutante
    /// </summary>
    public class SpecieController : ControllerBase
    {
        private readonly ISpecieService _specieService;    
        public SpecieController(ISpecieService specieService)
        {
            _specieService = specieService;
        }


      /// <summary>
      /// Servicio en donde se puede detectar si un humano es mutante validando la secuencia de ADN mediante el método POST
      /// </summary>
      /// <param name="especieModel"></param>
      /// <returns>En caso de verificar un mutante devuelve un HTTP 200-ok, en caso contrario un 403-Forbidden</returns>
        [HttpPost]
        [Route("/mutant")]
        [ProducesResponseType(200)]
        [ProducesResponseType(403)]
        [Produces("application/json",Type =typeof(SpecieViewModel))]
        public async Task<IActionResult> mutant([FromBody]SpecieViewModel especieModel)
        {
            if (await _specieService.IsMutant(especieModel.adn))
                return Ok();
            else
            {
                return new StatusCodeResult(Convert.ToInt32(403));
                //Response.StatusCode = 403;
                //HttpContext.Response.StatusCode = 403;
                //return BadRequest();
            }
                //return BadRequest(;
        }

        /// <summary>
        /// Servicio extra que devuelve en Json las estadisticas de las verificaciones de ADN
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/stats")]
        [Produces("application/json", Type = typeof(StatsViewModel))]
        public async Task<IActionResult> stats()
        {
            return Ok(await _specieService.GetValueStatistics());
        }

    }
}