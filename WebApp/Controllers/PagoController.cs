using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeNegocio.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [LogueadoFilter]
    public class PagoController : Controller
    {
        private IAgregarPago _agregarPago;
        private IObtenerPagos _obtenerPagos;
        private IObtenerPagosDadoAnioYmes _listarPagosMensuales;

        public PagoController(
               IAgregarPago agregarPago, 
               IObtenerPagos obtenerPagos,                             
               IObtenerPagosDadoAnioYmes listarPagosMensuales
               )
        {
                _agregarPago = agregarPago;
                _obtenerPagos = obtenerPagos;
                _listarPagosMensuales = listarPagosMensuales;
        }

        [NoDisponibleFilter]
        public ActionResult Index()
        {
            
            return View(_obtenerPagos.ObtenerPagos());
        }

    
        public ActionResult Details(int id)
        {
            return View();
        }

       
        public IActionResult Create(string error)
        {
            ViewBag.Error = error;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagoDTO pagoDTO)
        {
            try
            {
                int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
                _agregarPago.AltaPago(pagoDTO, usuarioId);
                ViewBag.Mensaje = "Pago Registrado con exito";
                return View();
            }
            catch(PagoException pe)
            {
                ViewBag.Error = pe.Message;
                return View();
            }catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [GerenteFilter]
        public IActionResult ListarPagosMensuales()
        {
            return View();
        }
        [GerenteFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ListarPagosMensuales(int mes, int anio)
        {
            var pagos = _listarPagosMensuales.ObtenerPagosPorMesYAño(mes, anio);

            if (!pagos.Any())
                ViewBag.Mensaje = "No existen pagos registrados en ese período.";

            return View(pagos);
        }

    }
}



