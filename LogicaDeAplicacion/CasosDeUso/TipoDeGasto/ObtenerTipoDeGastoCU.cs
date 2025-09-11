using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.Mappers;
using LogicaDeNegocio.InterfacesRepositorio;
using LogicaDeNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class ObtenerTipoDeGastoCU : IObtenerTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        
        public ObtenerTipoDeGastoCU(ITipoDeGastoRepository repo) 
        { 
            _repo = repo; 
        }

        public IEnumerable<TipoDeGastoDTO> ObtenerTipoDeGasto()
        {
            List<TipoDeGastoDTO> toReturn = new List<TipoDeGastoDTO> ();
            foreach(LogicaDeNegocio.Entidades.TipoDeGasto tipo in _repo.GetAll())
            {
                toReturn.Add(TipoDeGastoMapper.ToDTO(tipo));
            }
            return toReturn;
        }
    }
}
