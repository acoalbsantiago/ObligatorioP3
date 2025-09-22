using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoADatos.EF;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Exceptions;
using LogicaDeNegocio.InterfacesRepositorio;

namespace AccesoADatos.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ObligatorioContext _context;

        public UsuarioRepository(ObligatorioContext contexto) 
        {
            _context = contexto;
        }

        public void Add(Usuario value)
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuario;
        }

        public Usuario Login(string pass, string email)
        {
            foreach(Usuario usuario in _context.Usuario)
            {
                if (usuario.Email.Correo == email)
                {
                    if (usuario.Password == pass)
                    {
                        return usuario;
                    }
                    throw new UsuarioException("Nombre de usuario o contraseña incorrecta");
                }
            }
            throw new UsuarioException("Nombre de usuario o contraseña incorrecta");
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> UsuariosPorMonto(double monto)
        {
            throw new NotImplementedException();
        }
    }
}
