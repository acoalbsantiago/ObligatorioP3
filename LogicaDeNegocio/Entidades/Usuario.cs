using LogicaDeNegocio.Enums;
using LogicaDeNegocio.Interfaces;
using LogicaDeNegocio.ValueObjets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Entidades
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable
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

        public Usuario () 
        {
           Email = new Email(Nombre, Apellido);
           Validar();
        }

        public void Validar()
        {
            //validar datos
            throw new NotImplementedException();
        }
    }
}
