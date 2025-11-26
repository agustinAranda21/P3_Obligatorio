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
            try
            {
                string token = HttpContext.Session.GetString("token");
                HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud("http://localhost:5207/api/TipoGasto?nombreTipoGasto=Marketing", "GET", null, token);
                HttpContent content = respuesta.Content;

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
