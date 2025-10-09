using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Pago
{
    public class ObtenerPagosSegunMontoTotalCU : IObtenerPagosSegunMontoTotal
    {
        private IPagoRepository _repo;

        public ObtenerPagosSegunMontoTotalCU(IPagoRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoDTO> ObtenerPagosSegunMontoTotal(double monto)
        {
            throw new NotImplementedException();
        }
    }
}
