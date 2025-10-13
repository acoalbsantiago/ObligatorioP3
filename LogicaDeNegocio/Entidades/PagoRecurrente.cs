using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class PagoRecurrente : Pago
    {
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public decimal? MontoMensual { get; set; }

        public PagoRecurrente(): base () { }

        public PagoRecurrente(decimal? montoMensual, DateTime? fechaDesde, DateTime? fechaHasta)
        {
            MontoMensual = montoMensual;
            FechaDesde = fechaDesde;
            FechaHasta = fechaHasta;
            MontoTotal = CalcularMontoTotalPeriodo();
        }

        public int? CalcularCantidadDeMeses()
        {
            return ((FechaHasta?.Year - FechaDesde?.Year) * 12)
                 + (FechaHasta?.Month - FechaDesde?.Month);
        }

        public decimal? CalcularMontoTotalPeriodo()
        {
            return MontoMensual * CalcularCantidadDeMeses();
        }

        public override decimal? CalcularSaldoPendiente(int mes, int año)
        {
            if (FechaDesde is null || FechaHasta is null)
                return 0;

            var periodo = new DateTime(año, mes, 1);

            if (periodo < FechaDesde || periodo > FechaHasta)
                return 0;

            int mesesRestantes = ((FechaHasta.Value.Year - año) * 12) + (FechaHasta.Value.Month - mes);
            return mesesRestantes > 0 ? mesesRestantes * MontoMensual : 0;
        }

    }
}
