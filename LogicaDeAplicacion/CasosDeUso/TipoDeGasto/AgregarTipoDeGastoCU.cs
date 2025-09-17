using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class AgregarTipoDeGastoCU : IAgregarTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        
        public AgregarTipoDeGastoCU(ITipoDeGastoRepository repo)
        {
            _repo = repo;
        }
        void IAgregarTipoDeGasto.AgregarTipoDeGasto(TipoDeGastoDTO tipoDeGasto)
        {
            _repo.Add(TipoDeGastoMapper.FromDTO(tipoDeGasto));
        }
    }
}
