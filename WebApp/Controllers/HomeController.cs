using System.Diagnostics;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers;


public class HomeController : Controller
{
    private ILogin _login;
    private IAltaUsuario _altaUsuario;

    public HomeController(ILogin ILogin, IAltaUsuario altaUsuario)
    {
        _login = ILogin;
        _altaUsuario = altaUsuario;
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(UsuarioDTO usuarioDTO)
    {
        try
        {
            //int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
            _altaUsuario.AgregarUsuario(usuarioDTO);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            return View();
        }
    }

}
