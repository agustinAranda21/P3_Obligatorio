using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3_Dominio.Exceptions;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private IObtenerPagoPorId _pagos;
        private IAddPago _addPago;

        public PagoController(IObtenerPagoPorId pagos, IAddPago addPago)
        {
            _pagos = pagos;
            _addPago = addPago;
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
    }
}
