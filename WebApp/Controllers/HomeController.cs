using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ILogin _login;

        public HomeController(ILogin login)
        {
            _login = login;
        }
        public IActionResult Index(string error)
        {
            ViewBag.Error = error;
            return View();

        }
        public IActionResult Login(string error)
        {
            ViewBag.Error = error;
            return View();
        }
        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            try
            {
                UsuarioDTO logueado = this._login.Login(Email, Password);
                HttpContext.Session.SetString("email", logueado.Email.Correo);
                HttpContext.Session.SetInt32("usuarioId", logueado.Id);
                HttpContext.Session.SetString("rol", logueado.Rol);
                return RedirectToAction("Index", "Home");
            }
            catch (UsuarioException uex)
            {
                ViewBag.Error = uex.Message;
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Sucedio un error inesperado";
                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
