using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAppClienteHttp.Auxiliares;
using WebAppClienteHttp.DTOs;

namespace WebAppClienteHttp.Controllers
{
    public class EquipoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult EquiposPorMonto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EquiposPorMonto(double monto)
        {
            try
            {
                string url = $"https://localhost:7254/api/Equipos/montoMayorA/{monto}";

                HttpResponseMessage respuesta =
                    AuxiliarClienteHttp.EnviarSolicitud(url, "GET", null);

                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (!respuesta.IsSuccessStatusCode)
                {
                    ViewBag.Error = body;
                    return View();
                }

                List<EquipoDTO> equipos =
                    JsonConvert.DeserializeObject<List<EquipoDTO>>(body);

                return View(equipos);
            }
            catch
            {
                ViewBag.Error = "Error inesperado.";
                return View();
            }
        }
    }
}
    

