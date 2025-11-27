using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebAppClienteHttp.Auxiliares;
using WebAppClienteHttp.DTOs;
using WebAppClienteHttp.Exceptions;
using WebAppClienteHttp.ViewModels;

namespace WebAppClienteHttp.Controllers
{
    public class PagoController : Controller
    {

        public PagoController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult AddPagoUnico()
        {
            IEnumerable<TipoGastoDTO> tiposGasto = new List<TipoGastoDTO>();
            IEnumerable<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            try
            {
                HttpResponseMessage respuestaTipos = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/TipoGasto/listarTodos", "GET", null);
                HttpResponseMessage respuestaUsuarios = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Usuario/listarTodos", "GET", null);
                HttpContent content = respuestaTipos.Content;
                HttpContent content1 = respuestaUsuarios.Content;

                string body = AuxiliarClienteHttp.ObtenerBody(respuestaTipos);
                string body1 = AuxiliarClienteHttp.ObtenerBody(respuestaUsuarios);

                if (respuestaTipos.IsSuccessStatusCode)
                {
                    tiposGasto = JsonConvert.DeserializeObject<IEnumerable<TipoGastoDTO>>(body);
                }

                if (respuestaUsuarios.IsSuccessStatusCode)
                {
                    usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(body1);
                }

            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
            }

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios,
                FechaDePago = DateTime.Today
            };
            return View(viewModel);
        }

        
        [HttpPost]
        public IActionResult AddPagoUnico(AddPagoViewModel model)
        {
            IEnumerable<TipoGastoDTO> tiposGasto = new List<TipoGastoDTO>();
            IEnumerable<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios,
                FechaDePago = DateTime.Today
            };

            try
            {
                HttpResponseMessage respuestaTipos = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/TipoGasto/listarTodos", "GET", null);
                HttpResponseMessage respuestaUsuarios = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Usuario/listarTodos", "GET", null);
                HttpContent content = respuestaTipos.Content;
                HttpContent content1 = respuestaUsuarios.Content;

                string body = AuxiliarClienteHttp.ObtenerBody(respuestaTipos);
                string body1 = AuxiliarClienteHttp.ObtenerBody(respuestaUsuarios);

                if (respuestaTipos.IsSuccessStatusCode)
                {
                    tiposGasto = JsonConvert.DeserializeObject<IEnumerable<TipoGastoDTO>>(body);
                }

                if (respuestaUsuarios.IsSuccessStatusCode)
                {
                    usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(body1);
                }

                model.TiposGasto = tiposGasto;
                model.Usuarios = usuarios;
                viewModel.TiposGasto = tiposGasto;
                viewModel.Usuarios = usuarios;


                UnicoDTO nuevo = new UnicoDTO()
                {
                    MetodoDePago = new MetodoDePagoDTO { Metodo = model.MetodoDePago },
                    TipoGastoId = model.TipoGastoId,
                    UsuarioId = model.UsuarioId,
                    Descripcion = model.Descripcion,
                    Monto = model.Monto,
                    SaldoPendiente = 0,
                    FechaDePago = model.FechaDePago,
                    NumeroDeRecibo = model.NumeroDeRecibo
                };

                HttpResponseMessage respuestaCreacion = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Pago/unico", "POST", nuevo);
                HttpContent contentCreacion = respuestaCreacion.Content;
                string bodyCreacion = AuxiliarClienteHttp.ObtenerBody(respuestaCreacion);
                if(respuestaCreacion.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Pago registrado con éxito.";
                }
                else
                {
                    ViewBag.Error = "Error al registrar el pago: <br>" + bodyCreacion;
                    return View(viewModel);
                }


                ViewBag.Mensaje = "Pago registrado con éxito.";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error, verifique los datos: <br>" + ex.Message;
                return View(viewModel);
            }
        } 

        
        public IActionResult AddPagoRecurrente()
        {
            IEnumerable<TipoGastoDTO> tiposGasto = new List<TipoGastoDTO>();
            IEnumerable<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            try
            {
                HttpResponseMessage respuestaTipos = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/TipoGasto/listarTodos", "GET", null);
                HttpResponseMessage respuestaUsuarios = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Usuario/listarTodos", "GET", null);
                HttpContent content = respuestaTipos.Content;
                HttpContent content1 = respuestaUsuarios.Content;

                string body = AuxiliarClienteHttp.ObtenerBody(respuestaTipos);
                string body1 = AuxiliarClienteHttp.ObtenerBody(respuestaUsuarios);

                if (respuestaTipos.IsSuccessStatusCode)
                {
                    tiposGasto = JsonConvert.DeserializeObject<IEnumerable<TipoGastoDTO>>(body);
                }

                if (respuestaUsuarios.IsSuccessStatusCode)
                {
                    usuarios = JsonConvert.DeserializeObject<IEnumerable<UsuarioDTO>>(body1);
                }

            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
            }

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios,
                Desde = DateTime.Today,
                Hasta = DateTime.Today
            };
            return View(viewModel);
        }

       
        [HttpPost]
        public IActionResult AddPagoRecurrente(AddPagoViewModel model)
        {

            IEnumerable<TipoGastoDTO> tiposGasto = new List<TipoGastoDTO>();
            IEnumerable<UsuarioDTO> usuarios = new List<UsuarioDTO>();

            AddPagoViewModel viewModel = new AddPagoViewModel
            {
                TiposGasto = tiposGasto,
                Usuarios = usuarios,
                Desde = DateTime.Today,
                Hasta = DateTime.Today
            };

            try
            {
                model.TiposGasto = tiposGasto;
                model.Usuarios = usuarios;

                RecurrenteDTO nuevo = new RecurrenteDTO()
                {
                    MetodoDePago = new MetodoDePagoDTO { Metodo = model.MetodoDePago },
                    TipoGastoId = model.TipoGastoId,
                    UsuarioId = model.UsuarioId,
                    Descripcion = model.Descripcion,
                    Monto = model.Monto,
                    SaldoPendiente = 0,
                    Desde = model.Desde,
                    Hasta = model.Hasta
                };

                HttpResponseMessage respuestaCreacion = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Pago/recurrente", "POST", nuevo);
                string bodyCreacion = AuxiliarClienteHttp.ObtenerBody(respuestaCreacion);
                if (respuestaCreacion.IsSuccessStatusCode)
                {
                    ViewBag.Mensaje = "Pago registrado con éxito.";
                }
                else
                {
                    ViewBag.Error = "Error al registrar el pago: <br>" + bodyCreacion;
                    return View(viewModel);
                }


                ViewBag.Mensaje = "Pago registrado con éxito.";
                return View(viewModel);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error, verifique los datos: <br>" + ex.Message;
                return View(viewModel);
            }
        }

        public IActionResult ListarPagosPorUsuario()
        {
            List<PagoDTO> pagos = new List<PagoDTO>();
            return View(pagos);
        }

        [HttpPost]
        public IActionResult ListarPagosPorUsuario(int IdUsuario)
        {
            List<PagoDTO> pagos = new List<PagoDTO>();

            try
            {
                HttpResponseMessage respuesta =
                    AuxiliarClienteHttp.EnviarSolicitud(
                        $"https://localhost:7254/api/Pago/usuario/{IdUsuario}",
                        "GET",
                        null
                    );

                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    List<JObject> listaJson = JsonConvert.DeserializeObject<List<JObject>>(body);

                    foreach (JObject item in listaJson)
                    {
                        UnicoDTO posibleUnico = item.ToObject<UnicoDTO>();

                        if (posibleUnico.FechaDePago != DateTime.MinValue &&
                            posibleUnico.NumeroDeRecibo != null)
                        {
                            pagos.Add(posibleUnico);
                        }
                        else
                        {
                            RecurrenteDTO posibleRecurrente = item.ToObject<RecurrenteDTO>();
                            pagos.Add(posibleRecurrente);
                        }
                    }
                }
                else
                {
                    ViewBag.Error = "Error al obtener los pagos: <br>" + body;
                }

                return View(pagos);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error, verifique los datos: <br>" + ex.Message;
                return View(pagos);
            }
        }

    }
}
