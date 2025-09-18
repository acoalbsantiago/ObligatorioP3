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
    public class EditarTipoDeGastoCU : IEditarTipoDeGasto
    {
        private ITipoDeGastoRepository _repo;

        public EditarTipoDeGastoCU(ITipoDeGastoRepository repo)
        {
            _repo = repo;
        }
        public void EditarTipoDeGasto(TipoDeGastoDTO tipoDTO)
        {
           LogicaDeNegocio.Entidades.TipoDeGasto tipo = _repo.FindById(tipoDTO.Id);
           
            tipo.Nombre = tipoDTO.Nombre;
            tipo.Descripcion = tipoDTO.Descripcion;

            _repo.Update(tipo);
        }
    }
}
