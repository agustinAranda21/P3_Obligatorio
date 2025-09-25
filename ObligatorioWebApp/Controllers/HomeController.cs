using System.Diagnostics;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.AspNetCore.Mvc;
using ObligatorioWebApp.Filters;
using P3_Dominio.Exceptions;

namespace ObligatorioWebApp.Controllers;

public class HomeController : Controller
{
    private ILogin _login;

    public HomeController(ILogin login)
    {
        _login = login;
    }
    [LogueadoFilter]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Login(string error)
    {
        ViewBag.Error = error;
        return View();
    }
    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        try
        {
            UsuarioDTO logueado = _login.Login(email, password);
            HttpContext.Session.SetString("usuario", logueado.Nombre);
            HttpContext.Session.SetString("usuarioApellido", logueado.Apellido);
            HttpContext.Session.SetInt32("usuarioId", logueado.Id);
            HttpContext.Session.SetString("usuarioRol", logueado.RolDeUsuario.TipoRol.ToString());
            return RedirectToAction("Index");
        }
        catch (UsuarioException uex)
        {
            ViewBag.Error = uex.Message;
            return View();
        } catch (Exception ex)
        {
            ViewBag.Error = "Sucedió un error inesperado";
            return View();
        }

    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}

