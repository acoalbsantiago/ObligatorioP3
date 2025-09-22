using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Entidades;

namespace LogicaDeNegocio.InterfacesRepositorio
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        public IEnumerable<Usuario> UsuariosPorMonto (double monto);
        public Usuario Login(string pass, string email); 
    }
}
