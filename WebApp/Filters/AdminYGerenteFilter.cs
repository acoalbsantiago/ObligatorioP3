using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class AdminYGerenteFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrWhiteSpace(rol) || (rol != "ADMINISTRADOR" && rol != "GERENTE"))
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Home",
                    new { error = "Debe ser Administrador o gerente para acceder" }
                );
            }

            base.OnActionExecuting(context);
        }
    }
}
