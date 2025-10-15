using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Filters
{
    public class LogueadoFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpContext = context.HttpContext;
            string? usuario = httpContext.Session.GetString("usuario");
            int? usuarioId = httpContext.Session.GetInt32("usuarioId");

            if (string.IsNullOrWhiteSpace(usuario) || usuarioId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Home", new { error = "Debe iniciar sesión" });
                return;
            }

            // Guardamos el usuarioId en Items para que esté disponible en el request actual
            httpContext.Items["UsuarioId"] = usuarioId.Value;
            httpContext.Items["UsuarioNombre"] = usuario;
        }
    }
}
