using LogicaAplicacion.CasosDeUso.TipoGasto;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatorioWebApp.Filters;
using P3_Dominio.Entities;
using P3_Dominio.Exceptions;

namespace ObligatorioWebApp.Controllers
{
    public class TipoGastoController : Controller
    {
        private IAddTipoGasto _crear;
        private IEliminarTipoGasto _eliminar;
        private IObtenerTiposGasto _obtener;
        private IEditarTipoGasto _editar;
        private IAddAuditoriaTipoGasto _auditoria;
        private IObtenerTipoGastoPorId _obtenerPorId;
        private IObtenerPagos _obtenerPagos;


        public TipoGastoController(IAddTipoGasto crear, IEliminarTipoGasto eliminar, IObtenerTiposGasto obtener, IEditarTipoGasto editar, IAddAuditoriaTipoGasto auditoria, IObtenerTipoGastoPorId obtenerPorId, IObtenerPagos obtenerPagos)
        {
            _crear = crear;
            _eliminar = eliminar;
            _obtener = obtener;
            _editar = editar;
            _auditoria = auditoria;
            _obtenerPorId = obtenerPorId;
            _obtenerPagos = obtenerPagos;
        }
        [LogueadoFilter]
        [AdministradorFilter]
        public IActionResult Index()
        {
            IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
            List<TipoGastoDTO> listaTipos = lista.ToList();
            return View(listaTipos);
        }

        [LogueadoFilter]
        [AdministradorFilter]
        public IActionResult AddTipoGasto()
        {
            if(HttpContext.Session.GetString("usuarioRol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [LogueadoFilter]
        [AdministradorFilter]
        [HttpPost]
        public IActionResult AddTipoGasto(TipoGastoDTO nuevoDto)
        {
            try
            {
                _crear.Add(nuevoDto);
                AuditoriaTipoGastoDTO auditoria = new AuditoriaTipoGastoDTO
                {
                    Nombre = nuevoDto.Nombre,
                    Descripcion = nuevoDto.Descripcion,
                    Accion = "Creación",
                    Fecha = DateTime.Now,
                    Usuario = HttpContext.Session.GetString("usuarioApellido") 
                }; 
                _auditoria.Add(auditoria);
                ViewBag.Mensaje = "Tipo de gasto creado con éxito.";
                return View();
            }
            catch (TipoGastoException ex)
            {
                ViewBag.Error = "Error relacionado con los tipos de gasto: " + ex.Message;
                return View();
            }
        }

        [LogueadoFilter]
        [AdministradorFilter]
        public IActionResult EliminarTipoGasto()
        {
            try
            {
                if (HttpContext.Session.GetString("usuarioRol") != "Administrador")
                {
                    return RedirectToAction("Index", "Home");
                }
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                return View(lista);
            }
            catch (TipoGastoException ex)
            {
                ViewBag.Error = "Error relacionado con los tipos de gasto: " + ex.Message;
                return View();

            }
        }

        [LogueadoFilter]
        [AdministradorFilter]
        [HttpPost]
        public IActionResult EliminarTipoGasto(TipoGastoDTO dto)
        {
            try
            {
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                foreach(PagoDTO pago in _obtenerPagos.ObtenerPagos())
                {
                    if(pago.TipoGasto.Id == dto.Id)
                    {
                        ViewBag.Error = "No se puede eliminar el tipo de gasto porque está asociado a uno o más pagos.";
                        return View(lista);
                    }
                }
                    _eliminar.Remove(dto.Id);
                    AuditoriaTipoGastoDTO auditoria = new AuditoriaTipoGastoDTO
                    {
                        Nombre = dto.Nombre,
                        Descripcion = dto.Descripcion,
                        Accion = "Eliminación",
                        Fecha = DateTime.Now,
                        Usuario = HttpContext.Session.GetString("usuarioApellido")
                    };
                    _auditoria.Add(auditoria);
                    ViewBag.Mensaje = "Tipo de gasto eliminado con éxito.";
                return View(lista);
            }
            catch (TipoGastoException ex)
            {
                ViewBag.Error = "Error relacionado con los tipos de gasto: " + ex.Message;
                return View();
            }
        }

        [LogueadoFilter]
        [AdministradorFilter]
        public IActionResult EditarTipoGasto()
        {
            try
            {
                if (HttpContext.Session.GetString("usuarioRol") != "Administrador")
                {
                    return RedirectToAction("Index", "Home");
                }
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                return View(lista);
            }
            catch (TipoGastoException ex)
            {
                ViewBag.Error = "Error relacionado con los tipos de gasto: " + ex.Message;
                return View();
            }
            }

        [LogueadoFilter]
        [AdministradorFilter]
        [HttpPost]
        public IActionResult EditarTipoGasto(TipoGastoDTO dto)
        {
            try
            {
                _editar.Update(dto);
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                AuditoriaTipoGastoDTO auditoria = new AuditoriaTipoGastoDTO
                {
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    Accion = "Actualización",
                    Fecha = DateTime.Now,
                    Usuario = HttpContext.Session.GetString("usuarioApellido")
                };
                _auditoria.Add(auditoria);
                ViewBag.Message = "Tipo de gasto editado con éxito.";
                return View(lista);
            }
            catch (TipoGastoException ex)
            {
                ViewBag.Error = "Error relacionado con los tipos de gasto: " + ex.Message;
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                return View(lista);
            }

        }
    }
}
