using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioWebApp.Filters
{
    public class GerenteFilter  : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string logueado = context.HttpContext.Session.GetString("usuarioRol");
            if (!logueado.Equals("Gerente"))
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { error = "No tiene permisos." });
            }
            base.OnActionExecuting(context);
        }
    }
}
