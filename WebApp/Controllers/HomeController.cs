using System.Diagnostics;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers;


public class HomeController : Controller
{
    private ILogin _login;

    public HomeController(ILogin ILogin)
    {
        _login = ILogin;
    }

    [LogueadoFilter]
    public IActionResult Index()
    {
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
            HttpContext.Session.SetString("usuario", logueado.Nombre);
            HttpContext.Session.SetInt32("usuarioId", logueado.Id);
            return RedirectToAction("Index");
        }
        catch (UsuarioException uex)
        {
            ViewBag.Error = uex.Message;
            return View();
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Sucedio un error inesperado";
            return View();
        }
      
    }

}
