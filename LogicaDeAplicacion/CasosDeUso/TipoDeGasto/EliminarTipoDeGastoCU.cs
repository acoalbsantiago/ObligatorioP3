using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class EliminarTipoDeGastoCU: IEliminarTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        public EliminarTipoDeGastoCU( ITipoDeGastoRepository tipoDeGastoRepository) 
        {
            _repo = tipoDeGastoRepository;
        }

        public void EliminarTipoDeGasto(int id)
        {
            _repo.Remove(id);
        }
    }
}
