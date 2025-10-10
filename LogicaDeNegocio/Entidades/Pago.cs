using LogicaDeNegocio.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public abstract class Pago
    {
        public int Id { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public string Descripcion { get; set; }
        public TipoDeGasto TipoDeGasto { get; set; }
        [ForeignKey("TipoDeGasto")]
        public int TipoDeGastoId { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public decimal MontoTotal { get; set; }
        
        public Pago() { }
    }
}
