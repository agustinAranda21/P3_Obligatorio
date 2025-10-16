using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioWebApp.Filters
{
    public class AdministradorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string logueado = context.HttpContext.Session.GetString("usuarioRol");
            if (!logueado.Equals("Administrador"))
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { error = "No tiene permisos." });
            }
            base.OnActionExecuting(context);
        }
    }
}
