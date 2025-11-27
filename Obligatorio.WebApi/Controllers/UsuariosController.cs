using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IResetearPassUsuario _resetearPassUsuario;

        public UsuariosController(IResetearPassUsuario resetearPassUsuario)
        {
            if (resetearPassUsuario == null)
            {
                throw new Exception("resetearPassUsuario");
            }
            _resetearPassUsuario = resetearPassUsuario;
        }

        [HttpPut("resetearPass/{idUsuario}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public ActionResult<string> ResetPassword(int idUsuario)
        {
            try
            {
                string nuevaPass = _resetearPassUsuario.ResetearPass(idUsuario);
                return Ok(nuevaPass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
