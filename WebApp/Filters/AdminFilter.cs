namespace WebApp.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;

    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var rol = context.HttpContext.Session.GetString("rol");

            if (string.IsNullOrWhiteSpace(rol) || rol != "ADMINISTRADOR")
            {
                context.Result = new RedirectToActionResult(
                    "Index",
                    "Home",
                    new { error = "Debe ser Administrador para acceder a esta sección" }
                );
            }

            base.OnActionExecuting(context);
        }
    }

}
