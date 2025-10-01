using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class PagoUnico : Pago
    {
        public DateTime? FechaPago { get; set; }
        public int NumFactura { get; set; }

        public PagoUnico(): base() { }
    }
}
