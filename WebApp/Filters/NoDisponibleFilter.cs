using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Filters
{
    public class NoDisponibleFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new RedirectToActionResult("Index", "Home", new { error = "Funcionalidad en desarrollo" });
            base.OnActionExecuting(context);
        }
    }
}
