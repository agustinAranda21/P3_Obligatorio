using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesEquipo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EquiposController : ControllerBase
    {
        private IObtenerEquiposPorMontoMayorA _obtenerEquiposPorMontoMayorA;

        public EquiposController(IObtenerEquiposPorMontoMayorA obtenerEquiposPorMontoMayorA)
        {
            if (obtenerEquiposPorMontoMayorA == null)
            {
                throw new ArgumentNullException("obtenerEquiposPorMontoMayorA");
            }

            _obtenerEquiposPorMontoMayorA = obtenerEquiposPorMontoMayorA;
        }

        [HttpGet("montoMayorA/{monto}")]
        [ProducesResponseType(typeof(IEnumerable<EquipoDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<EquipoDTO>> ObtenerEquiposPorMontoMayorA(double monto)
        {
            try
            {
                IEnumerable<EquipoDTO> equipos =
                    _obtenerEquiposPorMontoMayorA.ObtenerEquiposPorMontoMayorA(monto);

                return Ok(equipos);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is InvalidOperationException)
                    return BadRequest(ex.Message);

                return StatusCode(500, "Ocurrió un error inesperado.");
            }
        }
    }
}