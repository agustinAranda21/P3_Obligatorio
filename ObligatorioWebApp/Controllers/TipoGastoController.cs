using LogicaAplicacion.CasosDeUso.TipoGasto;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P3_Dominio.Entities;

namespace ObligatorioWebApp.Controllers
{
    public class TipoGastoController : Controller
    {
        private IAddTipoGasto _crear;
        private IEliminarTipoGasto _eliminar;
        private IObtenerTiposGasto _obtener;
        private IEditarTipoGasto _editar;
        private IAddAuditoriaTipoGasto _auditoria;

        public TipoGastoController(IAddTipoGasto crear, IEliminarTipoGasto eliminar, IObtenerTiposGasto obtener, IEditarTipoGasto editar, IAddAuditoriaTipoGasto auditoria)
        {
            _crear = crear;
            _eliminar = eliminar;
            _obtener = obtener;
            _editar = editar;
            _auditoria = auditoria;
        }

        // GET: TipoGastoController
        public IActionResult AddTipoGasto()
        {
            if(HttpContext.Session.GetString("usuarioRol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

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
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Sucedió un error inesperado";
                return View();
            }
        }

        public IActionResult EliminarTipoGasto()
        {
            if (HttpContext.Session.GetString("usuarioRol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
            return View(lista);
        }
        [HttpPost]
        public IActionResult EliminarTipoGasto(TipoGastoDTO dto)
        {
            try
            {
                _eliminar.Remove(dto.Id);
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                AuditoriaTipoGastoDTO auditoria = new AuditoriaTipoGastoDTO
                {
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    Accion = "Eliminación",
                    Fecha = DateTime.Now,
                    Usuario = HttpContext.Session.GetString("usuarioApellido")
                };
                _auditoria.Add(auditoria);

                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Sucedió un error inesperado";
                return View();
            }
        }

        public IActionResult EditarTipoGasto()
        {
            if (HttpContext.Session.GetString("usuarioRol") != "Administrador")
            {
                return RedirectToAction("Index", "Home");
            }
            IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
            return View(lista);
        }

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
                return View(lista);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Sucedió un error inesperado";
                IEnumerable<TipoGastoDTO> lista = _obtener.FindAll();
                return View(lista);
            }

        }
    }
}
