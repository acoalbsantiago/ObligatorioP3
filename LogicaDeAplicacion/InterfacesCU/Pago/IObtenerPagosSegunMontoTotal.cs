using LogicaDeAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.InterfacesCU.Pago
{
    internal interface IObtenerPagosSegunMontoTotal
    {
        public IEnumerable<PagoDTO> ObtenerPagosSegunMontoTotal(double monto);
    }
}
