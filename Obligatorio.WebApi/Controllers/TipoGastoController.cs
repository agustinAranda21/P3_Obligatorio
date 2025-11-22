using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoGastoController : ControllerBase
    {
        private IObtenerTipoGastoPorId _obtenerPorId;

        public TipoGastoController(IObtenerTipoGastoPorId obtenerPorId)
        {
            _obtenerPorId = obtenerPorId;
        }
    }
}
