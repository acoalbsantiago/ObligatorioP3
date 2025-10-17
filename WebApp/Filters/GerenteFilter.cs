using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filters
{
    public class GerenteFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrWhiteSpace(rol) || rol != "GERENTE")
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Home",
                    new { error = "Debe ser Gerente para acceder a esta sección" }
                );
            }

            base.OnActionExecuting(context);
        }
    }

}
