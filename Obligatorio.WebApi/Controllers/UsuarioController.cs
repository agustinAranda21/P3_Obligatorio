using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3_Dominio.Entities;

namespace Obligatorio.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ILogin _login;
        private IObtenerUsuarios _listarUsuarios;
        private IResetearPassUsuario _resetearPassUsuario;

        public UsuarioController(ILogin login, IObtenerUsuarios listarUsuarios, IResetearPassUsuario resetearPassUsuario)
        {
            _login = login;
            _listarUsuarios = listarUsuarios;
            _resetearPassUsuario = resetearPassUsuario;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                if (loginDTO == null)
                {
                    return BadRequest("El usuario no puede ser nulo.");
                }

                UsuarioDTO usuario = _login.Login(loginDTO.Email, loginDTO.Clave);
                string token = TokenHandler.GenerarToken(usuario);
                loginDTO.Token = token;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(loginDTO);
        }
        [Authorize]
        [HttpGet("listarTodos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult ListarUsuariosTodos()
        {
            try
            {
                IEnumerable<UsuarioDTO> lista = _listarUsuarios.ObtenerUsuarios();
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

        [Authorize]
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
