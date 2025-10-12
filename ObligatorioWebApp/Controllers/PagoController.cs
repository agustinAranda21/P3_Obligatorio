using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Mvc;
using ObligatorioWebApp.ViewModels;
using P3_Dominio.Enums;

namespace ObligatorioWebApp.Controllers
{
    public class PagoController : Controller
    {
        private IAddPago _pago;
        private IObtenerTiposGasto _tiposGasto;
        private IObtenerUsuarios _usuarios;
        private IObtenerTipoGastoPorId _obtenerTipoGastoPorId;
        private IObtenerUsuarioPorId _obtenerUsuarioPorId;
        private IObtenerPagos _obtenerPagos;

        public PagoController(IAddPago pago, IObtenerTiposGasto tiposGasto, IObtenerUsuarios usuarios, IObtenerTipoGastoPorId obtenerTipoGastoPorId, IObtenerUsuarioPorId obtenerUsuarioPorId, IObtenerPagos obtenerPagos)
        {
            _pago = pago;
            _tiposGasto = tiposGasto;
            _usuarios = usuarios;
            _obtenerTipoGastoPorId = obtenerTipoGastoPorId;
            _obtenerUsuarioPorId = obtenerUsuarioPorId;
            _obtenerPagos = obtenerPagos;
        }

        public IActionResult Index()
        {
            IEnumerable<PagoDTO> pagos = _obtenerPagos.ObtenerPagos();
            return View(pagos);
        }

        public IActionResult AddPagoUnico()
        {
            IEnumerable<TipoGastoDTO> tiposGasto = _tiposGasto.FindAll();
            IEnumerable<UsuarioDTO> usuarios = _usuarios.ObtenerUsuarios();

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPagoUnico(UnicoDTO pago)
        {
            try
            {
                int metodoDePagoId = Convert.ToInt32(Request.Form["MetodoDePago"]);
                int tipoGastoId = Convert.ToInt32(Request.Form["TipoGasto"]);
                int usuarioId = Convert.ToInt32(Request.Form["Usuario"]);

                pago.MetodoDePago = new MetodoDePagoDTO
                {
                    Metodo = (MetodoDePagoEnum)metodoDePagoId
                };
                
                pago.TipoGastoId = tipoGastoId;
                pago.UsuarioId = usuarioId;

                _pago.Add(pago);
                ViewBag.Mensaje = "Pago registrado con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Sucedió un error inesperado";
                return RedirectToAction("Index");
            }
        }
        
        public IActionResult AddPagoRecurrente()
        {
            IEnumerable<UsuarioDTO> usuarios = _usuarios.ObtenerUsuarios();
            IEnumerable<TipoGastoDTO> tiposGasto = _tiposGasto.FindAll();

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPagoRecurrente(RecurrenteDTO pago)
        {
            try
            {
                int metodoDePagoId = Convert.ToInt32(Request.Form["MetodoDePago"]);
                int tipoGastoId = Convert.ToInt32(Request.Form["TipoGasto"]);
                int usuarioId = Convert.ToInt32(Request.Form["Usuario"]);

                pago.MetodoDePago = new MetodoDePagoDTO
                {
                    Metodo = (MetodoDePagoEnum)metodoDePagoId
                };

                pago.TipoGastoId = tipoGastoId;
                pago.UsuarioId = usuarioId;

                _pago.Add(pago);
                ViewBag.Mensaje = "Pago registrado con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Sucedió un error inesperado";
                return RedirectToAction("Index");
            }
        }
        
    
    }

}
