using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.Pago;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.Pago
{
    public class AgregarPagoCU : IAgregarPago
    {
        private IPagoRepository _repo;
        public AgregarPagoCU(IPagoRepository repo) 
        {
            _repo = repo;
        }
        public void AltaPago(PagoDTO nuevoPago)
        {
            throw new NotImplementedException();
        }
    }
}
