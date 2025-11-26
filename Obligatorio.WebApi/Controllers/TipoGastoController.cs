using Humanizer;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3_Dominio.Entities;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGastoController : ControllerBase
    {
        private IListarAuditoriasTipoGasto _listarAuditorias;
        private IObtenerTiposGasto _tiposGasto;

        public TipoGastoController(IListarAuditoriasTipoGasto listarAuditorias, IObtenerTiposGasto tiposGasto)
        {
            _listarAuditorias = listarAuditorias;
            _tiposGasto = tiposGasto;
        }

        [HttpGet]
        public IActionResult ListarAuditoriasPorUsuario(String nombreTipoGasto)
        {
            if (nombreTipoGasto == null) return BadRequest("No se proporcionaron datos para el alta.");
            try
            {
                IEnumerable<AuditoriaTipoGastoDTO> lista = _listarAuditorias.ListarTodasLasAuditoriasTipoGasto(nombreTipoGasto);
                return Ok(lista);
            } catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);

            } catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor, intente nuevamente más tarde.");
            }
            
        }

        [HttpGet("listarTodos")]
        public IActionResult ListarTiposGasto()
        {
            try
            {
                IEnumerable<TipoGastoDTO> lista = _tiposGasto.FindAll();
                return Ok(lista);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor, intente nuevamente más tarde.");
            }
        }
    }
}
