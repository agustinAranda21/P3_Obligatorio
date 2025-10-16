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
            List<PagoDTO> listaPagos = pagos.ToList();
            return View(listaPagos);
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
            IEnumerable<TipoGastoDTO> tiposGasto = _tiposGasto.FindAll();
            IEnumerable<UsuarioDTO> usuarios = _usuarios.ObtenerUsuarios();

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios
            };

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
                ViewBag.Mensaje = "Pago registrado con éxito.";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error, verifique los datos.";
                return View(viewModel);
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
            IEnumerable<TipoGastoDTO> tiposGasto = _tiposGasto.FindAll();
            IEnumerable<UsuarioDTO> usuarios = _usuarios.ObtenerUsuarios();

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios
            };


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
                ViewBag.Mensaje = "Pago registrado con éxito.";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error, verifique los datos.";
                return View(viewModel);
            }
        }  

        public IActionResult ListadoMensual()
        {
            if (HttpContext.Session.GetString("usuarioRol") != "Gerente")
            {
                return RedirectToAction("Index", "Home");
            }
            IEnumerable<PagoDTO> pagos = _obtenerPagos.ObtenerPagos();
            List<PagoDTO> pagosPorFecha = pagos.ToList();
            return View(pagosPorFecha);
        }

        [HttpPost]
        public IActionResult ListadoMensual(DateTime unaFecha)
        {
            IEnumerable<PagoDTO> pagos = _obtenerPagos.ObtenerPagos();
            int mesSeleccionado = unaFecha.Month;
            int añoSeleccionado = unaFecha.Year;

            // Filtrar pagos únicos del mes seleccionado
            IEnumerable<PagoDTO> pagosUnicos = pagos.OfType<UnicoDTO>().Where(u => u.FechaDePago.Month == mesSeleccionado && u.FechaDePago.Year == añoSeleccionado).Cast<PagoDTO>();

            // Filtrar pagos recurrentes que aplican al mes seleccionado
            IEnumerable<PagoDTO> pagosRecurrentes = pagos.OfType<RecurrenteDTO>()
                .Where(r => (r.Desde.Year < añoSeleccionado || (r.Desde.Year == añoSeleccionado && r.Desde.Month <= mesSeleccionado)) &&
                            (r.Hasta.Year > añoSeleccionado || (r.Hasta.Year == añoSeleccionado && r.Hasta.Month >= mesSeleccionado)))
                .Select(r => 
                {
                    double añosRestantes = r.Hasta.Year - añoSeleccionado;
                    double mesesTotales = (añosRestantes * 12) + (r.Hasta.Month - mesSeleccionado);
                    r.SaldoPendiente = r.Monto * mesesTotales;
                    return r;
                })
                .Cast<PagoDTO>();

            // Combinar ambos tipos de pagos
            List<PagoDTO> pagosPorFecha = pagosUnicos.Concat(pagosRecurrentes).ToList();

            if (!pagosPorFecha.Any())
            {
                ViewBag.Error = "No se encontraron pagos en el mes y año indicados.";
            }

            return View(pagosPorFecha);

            /*IEnumerable<PagoDTO> pagos = _obtenerPagos.ObtenerPagos();
            List<PagoDTO> pagosPorFecha = new List<PagoDTO>();
            bool found = false;
            
            int mesSeleccionado = unaFecha.Month;
            int añoSeleccionado = unaFecha.Year;

            double saldoPendiente = 0;
            
            foreach (PagoDTO p in pagos)
            {
                if (p is UnicoDTO u && u.FechaDePago.Month == mesSeleccionado && u.FechaDePago.Year == añoSeleccionado)
                {
                    pagosPorFecha.Add(p);
                    found = true;
                }

                if(p is RecurrenteDTO r && 
                   ((r.Desde.Year < añoSeleccionado || (r.Desde.Year == añoSeleccionado && r.Desde.Month <= mesSeleccionado)) &&
                    (r.Hasta.Year > añoSeleccionado || (r.Hasta.Year == añoSeleccionado && r.Hasta.Month >= mesSeleccionado))))
                {
                    double añosRestantes = r.Hasta.Year - añoSeleccionado;
                    double mesesTotales = (añosRestantes * 12) + (r.Hasta.Month - mesSeleccionado);
                    saldoPendiente = r.Monto * mesesTotales;
                    p.SaldoPendiente = saldoPendiente;
                    pagosPorFecha.Add(p);
                    found = true;
                }
            }

            if (!found)
            {
                ViewBag.Error = "No se encontraron pagos en el mes y año indicados.";
            }*/
        }
    }

}
 