using System.Diagnostics;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers;
[LogueadoFilter]
public class HomeController : Controller
{
    private ILogin _login;

    public HomeController(ILogin ILogin)
    {
        _login = ILogin;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(string correo, string password)
    {
        try
        {
            UsuarioDTO logueado = this._login.Login(correo, password);
            HttpContext.Session.SetString("usuario", logueado.Nombre);
            HttpContext.Session.SetInt32("usuarioId", logueado.Id);
            return RedirectToAction("Index");
        }
        catch (UsuarioException ex)
        {
            ViewBag.Error = ex.Message;
            return View();
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Sucedio un error inesperado";
            return View();
        }

      
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
