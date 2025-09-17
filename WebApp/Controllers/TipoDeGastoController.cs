using LogicaDeAplicacion.CasosDeUso.TipoDeGasto;
using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TipoDeGastoController : Controller
    {

        private IObtenerTipoDeGasto _obtenerTiposDeGasto;
        private IAgregarTipoDeGasto _agregarTipoDeGasto;
        private IEliminarTipoDeGasto _eliminarTipoDeGasto;
        private IObtenerTipoDeGastoPorId _obtenerTipoDeGastoPorId;

        public TipoDeGastoController(
                    IObtenerTipoDeGasto obtenerTipoDeGasto,
                    IAgregarTipoDeGasto agregarTipoDeGasto,
                    IEliminarTipoDeGasto eliminarTipoDeGasto,
                    IObtenerTipoDeGastoPorId obtenerTipoDeGastoPorId)
        {
            _obtenerTiposDeGasto = obtenerTipoDeGasto;
            _agregarTipoDeGasto = agregarTipoDeGasto;
            _eliminarTipoDeGasto = eliminarTipoDeGasto;
            _obtenerTipoDeGastoPorId = obtenerTipoDeGastoPorId;

        }

        // GET: TipoDeGastoController
        public ActionResult Index()
        {
            
            return View(_obtenerTiposDeGasto.ObtenerTipoDeGasto());
        }

        // GET: TipoDeGastoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                _agregarTipoDeGasto.AgregarTipoDeGasto(tipoDeGasto);
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
            return View();
        }

        // POST: TipoDeGastoController/Edit/5
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

        // GET: TipoDeGastoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_obtenerTipoDeGastoPorId.ObtenerTipoDeGastoPorId(id));
        }

        // POST: TipoDeGastoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _eliminarTipoDeGasto.EliminarTipoDeGasto(id);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
    }
}
