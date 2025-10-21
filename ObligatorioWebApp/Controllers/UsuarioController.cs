using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesEquipo;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ObligatorioWebApp.Filters;
using ObligatorioWebApp.ViewModels;
using P3_Dominio.Entities;
using P3_Dominio.Exceptions;
using P3_Dominio.ValueObjects.UsuarioVO;
using System.Globalization;
using System.Text;

namespace ObligatorioWebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private IObtenerUsuarios _obtenerUsuarios;
        private IObtenerPagos _obtenerPagos;
        private IObtenerEquipos _obtenerEquipos;
        private IAddUsuario _altaUsuario;

        public UsuarioController(IObtenerUsuarios obtenerUsuarios, IObtenerPagos obtenerPagos, IAddUsuario altaUsuario, IObtenerEquipos obtenerEquipos)
        {
            _obtenerUsuarios = obtenerUsuarios;
            _obtenerPagos = obtenerPagos;
            _altaUsuario = altaUsuario;
            _obtenerEquipos = obtenerEquipos;
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
        [AdminYGerenteFilter]
        public IActionResult AltaUsuario()
        {
            IEnumerable<EquipoDTO> equipos = _obtenerEquipos.ObtenerEquipos();

            AddUsuarioViewModel viewModel = new AddUsuarioViewModel
            {
                Equipos = equipos
            };

            return View(viewModel);
        }

        [LogueadoFilter]
        [AdminYGerenteFilter]
        [HttpPost]
        public IActionResult AltaUsuario(AddUsuarioViewModel model)
        {

            IEnumerable<EquipoDTO> equipos = _obtenerEquipos.ObtenerEquipos();

            AddUsuarioViewModel viewModel = new AddUsuarioViewModel
            {
                Equipos = equipos
            };

            //Generar el email
            string primerasTresNombre = new string(LimpiarTexto(model.Nombre).Take(3).ToArray());
            string primerasTresApellido = new string(LimpiarTexto(model.Apellido).Take(3).ToArray());
            string emailGenerado = primerasTresNombre + primerasTresApellido + "@laEmpresa.com";

            try
            {
                model.Equipos = equipos;

                UsuarioDTO nuevo = new UsuarioDTO
                {
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Clave = model.Password,
                    Email = emailGenerado,
                    RolDeUsuario = new RolDTO { TipoRol = model.TipoRol },
                    EquipoId = model.EquipoId
                };

                _altaUsuario.AltaUsuario(nuevo);
                ViewBag.Mensaje = "Alta creada con éxito.";
                return View(model);
            }
            catch (UsuarioException ex)
            {
                ViewBag.Error = "Sucedió un error inesperado: " + ex.Message;
                return View(viewModel);
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

        private string LimpiarTexto(string texto)
        {
            // Normaliza el texto para separar las letras de los acentos.
            string textoNormalizado = texto.Normalize(NormalizationForm.FormD);

            // Elimina los caracteres que son acentos o diéresis (NonSpacingMark).
            string soloLetras = new string(textoNormalizado
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            soloLetras = soloLetras.Replace("ñ", "n").Replace("Ñ", "N");

            return soloLetras;
        }
    }
}
