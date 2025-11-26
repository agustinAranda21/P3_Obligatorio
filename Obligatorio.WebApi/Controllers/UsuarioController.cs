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

        public UsuarioController(ILogin login, IObtenerUsuarios listarUsuarios)
        {
            _login = login;
            _listarUsuarios = listarUsuarios;
        }

        [HttpPost("Login")]
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
        [HttpGet("listarTodos")]
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
    }
}
