using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    //[LogueadoFilter]
    public class PagoController : Controller
    {
        private IAgregarPago _agregarPago;
        private IObtenerPagos _obtenerPagos;

        public PagoController(
               IAgregarPago agregarPago, 
               IObtenerPagos obtenerPagos                              
               )
        {
                _agregarPago = agregarPago;
                _obtenerPagos = obtenerPagos;
        }

        public ActionResult Index()
        {
            //return View();
            return View(_obtenerPagos.ObtenerPagos());
        }

        // GET: PagoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PagoController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PagoDTO pagoDTO)
        {
            try
            {
                int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
                _agregarPago.AltaPago(pagoDTO, usuarioId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PagoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PagoController/Edit/5
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

        // GET: PagoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PagoController/Delete/5
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

    }
}



