using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3_Dominio.Exceptions;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IObtenerPagoPorId _pagos;

        public ValuesController(IObtenerPagoPorId pagos)
        {
            _pagos = pagos;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PagoDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PagoDTO> ObtenerDetallesDeUnPago(int id)
        {
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
    }
}
