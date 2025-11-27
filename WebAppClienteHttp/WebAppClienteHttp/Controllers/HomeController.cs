using System.Diagnostics;
using WebAppClienteHttp.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebAppClienteHttp.Exceptions;
using Newtonsoft.Json;
using WebAppClienteHttp.Auxiliares;

namespace ObligatorioWebApp.Controllers;

public class HomeController : Controller
{
    public HomeController() { }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(string email, string clave)
    {
        try
        {
            var logueado = new LoginDTO { Email = email, Clave = clave };

            HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Usuario/Login", "POST", logueado);
            string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

            if (!respuesta.IsSuccessStatusCode)
            {
                // Mostrar mensaje retornado por la API (400/500) y volver al formulario
                ViewBag.Mensaje = body;
                return View("Index");
            }

            var usuario = JsonConvert.DeserializeObject<UsuarioDTO>(body);
            if (usuario == null)
            {
                ViewBag.Mensaje = "Respuesta inválida del servidor.";
                return View("Index");
            }

            HttpContext.Session.SetString("email", usuario.Email);
            if(usuario.Id > 0)
            {
                HttpContext.Session.SetInt32("usuarioId", usuario.Id);
            }
            HttpContext.Session.SetString("token", usuario.Token);

            return RedirectToAction("Index", "Pago");
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Sucedió un error inesperado: " + ex.Message;
            return View("Index");
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}