using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.DTOs
{
    public class TipoDeGastoDTO
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nombre Invalido")]
        public string Nombre { get; set; }
        [DisplayName("Tipo de gasto descrip")]
        public string Descripcion { get; set; }
    }
}
