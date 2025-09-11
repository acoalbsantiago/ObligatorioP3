using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
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
            _context.Add(value);
        }

        public TipoDeGasto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoDeGasto> GetAll()
        {
            return _context.tipos;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoDeGasto value)
        {
            throw new NotImplementedException();
        }
    }
}
