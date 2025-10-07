﻿using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Usuario
{
    public class AltaUsuarioCU : IAltaUsuario
    {
        private IUsuarioRepository _repo;

        public AltaUsuarioCU (IUsuarioRepository usuarioRepository)
        {
            _repo = usuarioRepository;
        }
        public void AgregarUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = UsuarioMapper.FromDTO(usuarioDTO);

            while (_repo.ExisteMail(usuario.Email.Correo))
            {
                usuario.RegenerarCorreo();
            }
            _repo.Add(usuario);
        }
       
    }
}
