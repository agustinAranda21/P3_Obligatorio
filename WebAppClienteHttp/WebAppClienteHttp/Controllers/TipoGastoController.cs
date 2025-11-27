using WebAppClienteHttp.DTOs;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppClienteHttp.ViewModels;
using WebAppClienteHttp.Exceptions;
using Newtonsoft.Json;
using WebAppClienteHttp.Auxiliares;

namespace ObligatorioWebApp.Controllers
{
    public class TipoGastoController : Controller
    {
        public TipoGastoController()
        {

        }

        public IActionResult Index()
        {
            IEnumerable<AuditoriaTipoGastoDTO> auditorias = new List<AuditoriaTipoGastoDTO>();

            return View(auditorias);
        }

        [HttpPost]
        public IActionResult Index(int idTipoGasto)
        {
            IEnumerable<AuditoriaTipoGastoDTO> auditorias = new List<AuditoriaTipoGastoDTO>();
            try
            {
                string token = HttpContext.Session.GetString("token");
                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud($"https://localhost:7254/api/TipoGasto/listarAuditoriasPorIdTP/{idTipoGasto}", "GET", null, token);

                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (respuesta.IsSuccessStatusCode)
                {
                    auditorias = JsonConvert.DeserializeObject<IEnumerable<AuditoriaTipoGastoDTO>>(body);
                }
                else
                {
                    ViewBag.Mensaje = body;
                }
            }
            catch (Exception)
            {
                ViewBag.Mensaje = "Ocurrió un error inesperado.";
            }
            return View(auditorias);
        }

        //public IActionResult Index()
        //{
        //    IEnumerable<AuditoriaTipoGastoDTO> auditorias = new List<AuditoriaTipoGastoDTO>();

        //    HttpClient cliente = new HttpClient();
        //    try
        //    {
        //        Task<HttpResponseMessage> tarea1 = cliente.GetAsync("http://localhost:5207/api/TipoGasto?nombreTipoGasto=MarketingEditado");
        //        tarea1.Wait();
        //        HttpResponseMessage respuesta = tarea1.Result;
        //        HttpContent content = respuesta.Content;

        //        Task<string> tarea2 = content.ReadAsStringAsync();
        //        tarea2.Wait();

        //        string body = tarea2.Result;

        //        if(respuesta.IsSuccessStatusCode)
        //        {
        //            auditorias = JsonConvert.DeserializeObject<IEnumerable<AuditoriaTipoGastoDTO>>(body);
        //        } else
        //        {
        //            ViewBag.Mensaje = body;
        //        }
        //    } catch (Exception)
        //    {
        //        ViewBag.Mensaje = "Ocurrió un error inesperado.";
        //    }
        //    return View(auditorias);
        //}
    }
}
