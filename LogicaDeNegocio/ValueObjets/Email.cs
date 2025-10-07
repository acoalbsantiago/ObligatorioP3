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

        public Email () { }
        private Email(string correo)
        {
            Correo = correo.ToLower();
        }
    
        
        public static Email Crear(string nombre, string apellido)
        {
            string prefNombre = nombre.Length >= 3 ? nombre[..3] : nombre;
            string prefApellido = apellido.Length >= 3 ? apellido[..3] : apellido;
            string correo = $"{prefNombre}{prefApellido}@laempresa.com";
            return new Email(correo);
        }
        public static Email CrearSecundario(string nombre, string apellido)
        {
            Random random = new Random();
            int numRandom = random.Next(100, 999);
            string prefNombre = nombre.Length >= 3 ? nombre[..3] : nombre;
            string prefApellido = apellido.Length >= 3 ? apellido[..3] : apellido;
            string correo = $"{prefNombre}{prefApellido}{numRandom}@laempresa.com";
            return new Email(correo);
        }

    }

}
