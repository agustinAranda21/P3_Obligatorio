using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ObligatorioWebApp.Filters;
using P3_Dominio.Exceptions;

namespace ObligatorioWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private IObtenerUsuarios _obtenerUsuarios;
        private IObtenerPagos _obtenerPagos;

        public UsuarioController(IObtenerUsuarios obtenerUsuarios, IObtenerPagos obtenerPagos)
        {
            _obtenerUsuarios = obtenerUsuarios;
            _obtenerPagos = obtenerPagos;
        }
        
        [LogueadoFilter]
        public IActionResult Index()
        {
            try
            {
                List<UsuarioDTO> usuarios = _obtenerUsuarios.ObtenerUsuarios().ToList();
                return View(usuarios);
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = ex.Message;
                return View(new List<UsuarioDTO>());
            }
        }

        [LogueadoFilter]
        [GerenteFilter]
        public IActionResult ListarUsuariosMonto()
        {
            try
            {
                string usuarioRol = HttpContext.Session.GetString("usuarioRol");

                if (!usuarioRol.Equals("Gerente"))
                {
                    return RedirectToAction("Index", "Home");
                }

                List<UsuarioDTO> listaUsuariosVacia = new List<UsuarioDTO>();
                return View(listaUsuariosVacia);
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = "Error relacionado con usuarios: " + ex.Message;
                return View(new List<UsuarioDTO>());
            }
        }

        [HttpPost]
        [LogueadoFilter]
        [GerenteFilter]
        public IActionResult ListarUsuariosMonto(double unMonto)
        {
            try
            {
                string usuarioRol = HttpContext.Session.GetString("usuarioRol");

                if (!usuarioRol.Equals("Gerente"))
                {
                    return RedirectToAction("Index", "Home");
                }

                List<int> usuariosIds = _obtenerPagos.ObtenerPagos().Where(p => p.Monto > unMonto).Select(p => p.Usuario.Id).Distinct().ToList();
                List<UsuarioDTO> listaUsuarios = _obtenerUsuarios.ObtenerUsuarios().Where(u => usuariosIds.Contains(u.Id)).ToList();

                if(!listaUsuarios.Any())
                {
                    ViewBag.Error = "No se encontraron usuarios con pagos mayores a " + unMonto;
                    return View(new List<UsuarioDTO>());
                }

                ViewBag.Message = "Se cargaron los usuarios con pagos mayores a " + unMonto + " exitosamente.";
                return View(listaUsuarios);
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = "Error relacionado con usuarios: " + ex.Message;
                return View(new List<UsuarioDTO>());
            }
        }
    }
}
