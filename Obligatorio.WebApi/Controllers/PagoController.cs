using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3_Dominio.Exceptions;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IObtenerPagoPorId _pagos;
        private IAddPago _addPago;
        private IObtenerPagosPorUsuario _obtenerPagosPorUsuario;

        public PagoController(IObtenerPagoPorId pagos, IAddPago addPago, IObtenerPagosPorUsuario usuarioPago)
        {
            _pagos = pagos;
            _addPago = addPago;
            _obtenerPagosPorUsuario = usuarioPago;
        }

        [HttpGet("{id}", Name = "BuscarPorId")]
        [ProducesResponseType(typeof(PagoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
        public ActionResult<PagoDTO> ObtenerDetallesDeUnPago(int id)
        {
            if (id <= 0) return BadRequest("El id ingresado debe ser mayor que 0.");

            try
            {
                PagoDTO unPago = _pagos.ObtenerPorId(id);

                if (unPago == null)
                {
                    return NotFound();
                }

                return Ok(unPago);
            } 
            catch (PagoException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("unico")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult AltaPagoUnico([FromBody] UnicoDTO? pago)
        {
            if (pago == null) return BadRequest("No se proporcionaron datos para el alta.");
            try
            {
                _addPago.Add(pago);
            }
            catch (PagoException ex)
            {

                return BadRequest(ex.Message);
            } 
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor. Intente nuevamente más tarde.");
            }
            return CreatedAtRoute("BuscarPorId", new {id = pago.Id}, pago);
        }

        [HttpPost("recurrente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult AltaPagoRecurrente([FromBody] RecurrenteDTO? pago)
        {
            if (pago == null) return BadRequest("No se proporcionaron datos para el alta.");
            try
            {
                _addPago.Add(pago);
            }
            catch (PagoException ex)
            {

                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor. Intente nuevamente más tarde.");
            }
            return CreatedAtRoute("BuscarPorId", new { id = pago.Id }, pago);
        }

        [HttpGet("usuario/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult ListarPagosPorUsuario(int idUsuario)
        {
            if (idUsuario <= 0) return BadRequest("El id del usuario debe ser mayor que 0.");
            try
            {
                List<PagoDTO> lista = _obtenerPagosPorUsuario.ObtenerPorUsuario(idUsuario);
                return Ok(lista);
            }
            catch (PagoException ex)
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
