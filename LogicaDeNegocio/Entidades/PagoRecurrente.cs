using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

    }
}
