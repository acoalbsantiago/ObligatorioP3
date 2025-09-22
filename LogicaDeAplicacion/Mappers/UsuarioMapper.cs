using LogicaDeAplicacion.DTOs;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicaDeAplicacion.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTO usuarioDTO)
        {
            return new Usuario
            {
                Id = usuarioDTO.Id,
                Nombre = usuarioDTO.Nombre,
                Apellido = usuarioDTO.Apellido,
                Password = usuarioDTO.Password,
                Email = new Email(usuarioDTO.Email)
            };
        }

        public static UsuarioDTO ToDTO(Usuario usuario)
        {
            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Password = usuario.Password,
                Email = usuario.Email.Correo
            };
        }

    }
}
    