using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class TipoDeGastoRepository : ITipoDeGastoRepository
    {
        private ObligatorioContext _context;

        public TipoDeGastoRepository(ObligatorioContext context)
        {
            _context = context;
        }

        public void Add(TipoDeGasto value)
        {
            //validar antes
            //value.Validar();
            _context.tiposDeGasto.Add(value);
            _context.SaveChanges();
        }

        public TipoDeGasto FindById(int id)
        {
            TipoDeGasto tipo = _context.tiposDeGasto.SingleOrDefault(t => t.Id == id);

            if (tipo == null)
                throw new TipoDeGastoException("Tipo de gasto no encontrado.");

            return tipo;
        }

        public IEnumerable<TipoDeGasto> GetAll()
        {
            return _context.tiposDeGasto;
        }

        public void Remove(int id)
        {
            bool existenPagos = _context.pagos.Any(p => p.TipoDeGastoId == id);

            if (existenPagos)
            {
                throw new InvalidOperationException("No se puede eliminar el tipo de gasto porque tiene pagos asociados.");
            }
            TipoDeGasto aBorrar = new TipoDeGasto { Id = id };
            _context.tiposDeGasto.Remove(aBorrar);
            _context.SaveChanges();
        }

        public void Update(TipoDeGasto value)
        {
            //_context.tipos.Update(value);
            _context.SaveChanges();
        }
    }
}
