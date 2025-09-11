using LogicaDeAplicacion.InterfacesCU.Usuario;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Usuario
{
    public class AtlaDePagoCU : IAltaDePago
    {
        private  IPagoRepository _repo;
        public AtlaDePagoCU(IPagoRepository repo) 
        { 
            _repo = repo;
        }
        public void AltaDePago(Pago pago)
        {
            throw new NotImplementedException();
        }
    }
}
