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
            _context.tipos.Add(value);
            _context.SaveChanges();
        }

        public TipoDeGasto FindById(int id)
        {
            
            foreach(TipoDeGasto tipo in _context.tipos)
            {
                if(tipo.Id == id)
                {
                    return tipo;
                }
            }
            throw new TipoDeGastoException("Tipo de gasto no encontrado.");
        }

        public IEnumerable<TipoDeGasto> GetAll()
        {
            return _context.tipos;
        }

        public void Remove(int id)
        {
            TipoDeGasto aBorrar = new TipoDeGasto { Id = id };
            _context.tipos.Remove(aBorrar);
            _context.SaveChanges();
        }

        public void Update(TipoDeGasto value)
        {
            //_context.tipos.Update(value);
            _context.SaveChanges();
        }
    }
}
