using System.Diagnostics;
using WebAppClienteHttp.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebAppClienteHttp.Exceptions;
using Newtonsoft.Json;
using WebAppClienteHttp.Auxiliares;

namespace ObligatorioWebApp.Controllers;

public class HomeController : Controller
{

    public HomeController()
    {

    }
    public IActionResult Index(string error)
    {
        ViewBag.Error = error;
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        try
        {
            LoginDTO logueado = new LoginDTO { Email = email, Clave = password };

            HttpResponseMessage respuesta = AuxiliarClienteHttp.EnviarSolicitud("https://localhost:7254/api/Usuario/Login", "POST", logueado);
            string body = AuxiliarClienteHttp.ObtenerBody(respuesta);

            if (!respuesta.IsSuccessStatusCode) // Serie 400 o 500
            {
                // Redirige a Index (la vista que contiene el formulario) pasando el mensaje de error
                return RedirectToAction("Index", new { error = body });
            }

            UsuarioDTO usuario = JsonConvert.DeserializeObject<UsuarioDTO>(body); // en el body hay JSON
            if (usuario == null)
            {
                return RedirectToAction("Index", new { error = "Respuesta inválida del servicio de autenticación." });
            }

            HttpContext.Session.SetString("usuario", usuario.Nombre ?? string.Empty);
            HttpContext.Session.SetInt32("usuarioId", usuario.Id);
            HttpContext.Session.SetString("token", usuario.Token ?? string.Empty);
            return RedirectToAction("Index", "Contenido");
        }
        catch (Exception)
        {
            return RedirectToAction("Index", new { error = "Sucedió un error inesperado." });
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}