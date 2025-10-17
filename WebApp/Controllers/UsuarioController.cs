using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Equipo;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Filters;


namespace WebApp.Controllers;

[LogueadoFilter]
public class UsuarioController : Controller
{
    
    private IAltaUsuario _altaUsuario;
    private IObtenerEquipos _obtenerEquipos;
    private IObtenerUsuariosSegunMonto _obtenerUsuarioSegunMonto;

    public UsuarioController(
        IAltaUsuario altaUsuario,
        IObtenerEquipos obtenerEquipos,
        IObtenerUsuariosSegunMonto obtenerUsuarioSegunMonto)
    {
        _altaUsuario = altaUsuario;
        _obtenerEquipos = obtenerEquipos;
        _obtenerUsuarioSegunMonto = obtenerUsuarioSegunMonto;
    }

 
    public IActionResult Index(string error)
    {
        ViewBag.Error = error;
        return View();
 
    }
    
    
    
    [AdminYGerenteFilter]
    public IActionResult Create()
    {
        try
        {
            IEnumerable<EquipoDTO> equipos = _obtenerEquipos.ObtenerEquipos();
            ViewBag.Equipos = new SelectList(equipos, "Id", "Nombre");
            return View();
        }
        catch (Exception)
        {
            return View();
        }
        
    }

    [AdminYGerenteFilter]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(UsuarioDTO usuarioDTO)
    {
        try
        {
            //int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
            _altaUsuario.AgregarUsuario(usuarioDTO);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception)
        {
            ViewBag.Error = "Ocurrio un error inesperado";
            return View();
        }
    }

    [GerenteFilter]
    public IActionResult UsuariosQueSuperanPagoDado()
    {
        return View();
    }

    [GerenteFilter]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UsuariosQueSuperanPagoDado(decimal monto)
    {
        try
        {
            var usuarios = _obtenerUsuarioSegunMonto.ObtenerUsuariosSegunMonto(monto);
            return View(usuarios);
        }
        catch (Exception)
        {

            ViewBag.Error = "Ocurrio un error al filtrar los datos";
            return View();
        }
        
    }
   
}   
