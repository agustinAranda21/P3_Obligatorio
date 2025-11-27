using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebAppClienteHttp.Auxiliares;

namespace WebAppClienteHttp.Controllers
{
    public class UsuarioController : Controller
    {
        
        public IActionResult ResetPassword(string error, string nuevaPassword)
        {
            if (error != null)
                ViewBag.Error = error;

            if (nuevaPassword != null)
                ViewBag.NuevaPassword = nuevaPassword;

            return View(); 
        }

        
        [HttpPost]
        public IActionResult ResetPasswordPost(int idUsuario)
        {
            try
            {
                string token = HttpContext.Session.GetString("token");
                string url = $"https://localhost:7254/api/Usuario/resetearPass/{idUsuario}";

                HttpResponseMessage respuesta =
                    AuxiliarClienteHttp.EnviarSolicitud(url, "PUT", null, token);

                string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

                if (!respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("ResetPassword", new { error = body });
                }

                return RedirectToAction("ResetPassword", new { nuevaPassword = body });
            }
            catch
            {
                return RedirectToAction("ResetPassword", new { error = "Ocurrió un error inesperado." });
            }
        }
    }
}
