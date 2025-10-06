using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.ValueObjets
{
    [Owned]
    public class Email
    {
        public string Correo { get; private set; }

        public Email(string nombre, string apellido)
        {
            Correo = nombre+apellido;
        }
    
        
    }

}
