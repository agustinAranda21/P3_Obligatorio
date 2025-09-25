using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ObligatorioWebApp.Filters
{
    public class LogueadoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string logueado = context.HttpContext.Session.GetString("usuario");
            if(string.IsNullOrWhiteSpace(logueado))
            {
                context.Result = new RedirectToActionResult("Login", "Home", new { error = "Debe iniciar sesión" });
            }
            base.OnActionExecuting(context);
        }
    }
}
