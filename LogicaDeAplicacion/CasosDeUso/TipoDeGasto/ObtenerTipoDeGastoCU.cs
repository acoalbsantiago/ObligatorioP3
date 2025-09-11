using LogicaDeAplicacion.DTOs;
using LogicaDeAplicacion.InterfacesCU.TipoDeGasto;
using LogicaDeNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.CasosDeUso.TipoDeGasto
{
    public class ObtenerTipoDeGastoCU : IObtenerTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;
        public ObtenerTipoDeGastoCU(ITipoDeGastoRepository repo) { _repo = repo; }
        
        public IEnumerable<TipoDeGastoDTO> ObtenerTipoDeGasto()
        {
            throw new NotImplementedException();
        }
    }
}
