using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
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

        public IEnumerable<Pago> ObtenerPagosPorAnioYmes(int mes, int anio)
        {
            DateTime inicioMes = new DateTime(anio, mes, 1);
            DateTime finMes = inicioMes.AddMonths(1);

            IEnumerable<Pago> unicos = _context.pagos
                .OfType<PagoUnico>()
                .Include(p => p.Usuario)
                .Include(p => p.TipoDeGasto)
                .Where(p => p.FechaPago >= inicioMes && p.FechaPago < finMes)
                .ToList<Pago>();

            IEnumerable<Pago> recurrentes = _context.pagos
                .OfType<PagoRecurrente>()
                .Include(p => p.Usuario)
                .Include(p => p.TipoDeGasto)
                .Where(p => p.FechaDesde <= finMes && p.FechaHasta >= inicioMes)
                .ToList<Pago>();

            return unicos.Union(recurrentes);
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
