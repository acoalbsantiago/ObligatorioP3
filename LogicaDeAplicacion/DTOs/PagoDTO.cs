using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.DTOs
{
    public class PagoDTO
    {
        public int Id { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public string Descripcion { get; set; }
        public TipoDeGastoDTO? TipoDeGasto { get; set; }
        public int TipoDeGastoId { get; set; }
        public UsuarioDTO? Usuario { get; set; }
        public int UsuarioId { get; set; }
        public double MontoTotal { get; set; }

        public TipoDePago TipoDePago { get; set; }

        //si pago es recurrente
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }

        //si es pago unico
        public DateTime? FechaPago { get; set; }
        public int NumFactura { get; set; }

        public PagoDTO() { }
    }
}
