using System.Diagnostics;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Equipo;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers;


public class HomeController : Controller
{
    private ILogin _login;
    private IAltaUsuario _altaUsuario;
    private IObtenerEquipos _obtenerEquipos;
    private IObtenerUsuariosSegunMonto _obtenerUsuarioSegunMonto;

    public HomeController(ILogin ILogin,
        IAltaUsuario altaUsuario,
        IObtenerEquipos obtenerEquipos,
        IObtenerUsuariosSegunMonto obtenerUsuarioSegunMonto)
    {
        _login = ILogin;
        _altaUsuario = altaUsuario;
        _obtenerEquipos = obtenerEquipos;
        _obtenerUsuarioSegunMonto = obtenerUsuarioSegunMonto;
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
        try
        {
            var equipos = _obtenerEquipos.ObtenerEquipos();

            ViewBag.Equipos = new SelectList(equipos, "Id", "Nombre");
            return View();
        }
        catch (Exception ex)
        {
            return View();

        }
        
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
    public IActionResult UsuariosQueSuperanPagoDado()
    {
        return View();
    }
    [HttpPost]
    public IActionResult UsuariosQueSuperanPagoDado(decimal monto)
    {
        try
        {
            var usuarios = _obtenerUsuarioSegunMonto.ObtenerUsuariosSegunMonto(monto);
            return View(usuarios);
        }
        catch (Exception ex)
        {

            ViewBag.Error = "Ocurrio un error al filtrar los datos";
            return View();
        }
        
    }

}
