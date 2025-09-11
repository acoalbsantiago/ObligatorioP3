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
        IEnumerable<Usuario> UsuariosPorMonto (double monto);
    }
}
