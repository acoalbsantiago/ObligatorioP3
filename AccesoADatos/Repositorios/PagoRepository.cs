using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.Repositorios
{
    public class PagoRepository : IPagoRepository
    {
        private ObligatorioContext _context;

        public PagoRepository(ObligatorioContext context)
        {
            _context = context;
        }
        public void Add(Pago value)
        {
            _context.pagos.Add(value);
            _context.SaveChanges();
        }

        public Pago FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pago> GetAll()
        {
            return _context.pagos;
        }

        public IEnumerable<Pago> ObtenerPagosPorMesYAnio(int mes, int anio)
        {
            _context.pagos.Where(p => p.Fec)
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pago value)
        {
            throw new NotImplementedException();
        }
    }
}
