using LogicaDeAplicacion.CasosDeUso.TipoDeGasto;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    
    [LogueadoFilter]
    [AdminFilter]
    public class TipoDeGastoController : Controller
    {

        private IObtenerTipoDeGasto _obtenerTiposDeGasto;
        private IAgregarTipoDeGasto _agregarTipoDeGasto;
        private IEliminarTipoDeGasto _eliminarTipoDeGasto;
        private IObtenerTipoDeGastoPorId _obtenerTipoDeGastoPorId;
        private IEditarTipoDeGasto _editarTipoDeGasto;

        public TipoDeGastoController(
                    IObtenerTipoDeGasto obtenerTipoDeGasto,
                    IAgregarTipoDeGasto agregarTipoDeGasto,
                    IEliminarTipoDeGasto eliminarTipoDeGasto,
                    IObtenerTipoDeGastoPorId obtenerTipoDeGastoPorId,
                    IEditarTipoDeGasto editarTipoDeGasto)
        {
            _obtenerTiposDeGasto = obtenerTipoDeGasto;
            _agregarTipoDeGasto = agregarTipoDeGasto;
            _eliminarTipoDeGasto = eliminarTipoDeGasto;
            _obtenerTipoDeGastoPorId = obtenerTipoDeGastoPorId;
            _editarTipoDeGasto = editarTipoDeGasto;

        }

        // GET: TipoDeGastoController
        public ActionResult Index()
        {
            
            return View(_obtenerTiposDeGasto.ObtenerTipoDeGasto());
        }

        // GET: TipoDeGastoController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
               return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }            
        }

        // GET: TipoDeGastoController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: TipoDeGastoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoDeGastoDTO tipoDeGasto)
        {
            try
            {
                int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
                _agregarTipoDeGasto.AgregarTipoDeGasto(tipoDeGasto, usuarioId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoDeGastoController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
            
        }

        // POST: TipoDeGastoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoDeGastoDTO tipoDTO)
        {
            try
            {
                int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
                _editarTipoDeGasto.EditarTipoDeGasto(tipoDTO, usuarioId);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                
                return RedirectToAction(nameof(Index));
                
            }
        }

        // GET: TipoDeGastoController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Index));
               
            }
            
        }

        // POST: TipoDeGastoController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                int usuarioId = HttpContext.Session.GetInt32("usuarioId").Value;
                _eliminarTipoDeGasto.EliminarTipoDeGasto(id, usuarioId);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();

            }
        }
    }
}
