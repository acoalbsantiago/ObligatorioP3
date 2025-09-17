using LogicaDeNegocio.Enums;
using LogicaDeNegocio.ValueObjets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set;}
        public Email Email { get; set; }
        public RolUsuario Rol { get; set; }
        public List<Pago> Pagos { get; set; } = new List<Pago>();
        public Equipo Equipo { get; set; }
        [ForeignKey("Equipo")]
        public int EquipoId { get; set; }

        public Usuario () { }
    }
}
