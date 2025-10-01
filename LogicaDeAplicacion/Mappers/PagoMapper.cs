using LogicaDeAplicacion.DTOs;
using LogicaDeNegocio.Entidades;
using LogicaDeNegocio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeAplicacion.Mappers
{
    public class PagoMapper
    {
        public static Pago FromDTO (PagoDTO dto, int usuarioId)
        {        

            if (dto.TipoDePago == TipoDePago.Unico)
            {
                return new PagoUnico
                {
                    Id = dto.Id,
                    MetodoDePago = dto.MetodoDePago,
                    Descripcion = dto.Descripcion,
                    MontoTotal = dto.MontoTotal,
                    UsuarioId = usuarioId,
                    FechaPago = dto.FechaPago,
                    NumFactura = dto.NumFactura,
                    FechaDesde = null,
                    FechaHasta = null
            };
              
            }
            else if (dto.TipoDePago == TipoDePago.Recurrente)
            {
                pago.FechaDesde = dto.FechaDesde;
                pago.FechaHasta = dto.FechaHasta;
                pago.FechaPago = null;
                pago.NumFactura = null;
            }

        }

        public static PagoDTO ToDTO(Pago entity)
        {
            var dto = new PagoDTO
            {
                Id = entity.Id,
                MetodoDePago = entity.MetodoDePago,
                TipoDePago = entity.TipoDePago,
                Descripcion = entity.Descripcion,
                MontoTotal = entity.MontoTotal,
                UsuarioId = entity.UsuarioId
            };

            if (entity.TipoDePago == TipoDePago.Unico)
            {
                dto.FechaPago = entity.FechaPago;
                dto.NumFactura = entity.NumFactura;
            }
            else if (entity.TipoDePago == TipoDePago.Recurrente)
            {
                dto.FechaDesde = entity.FechaDesde;
                dto.FechaHasta = entity.FechaHasta;
            }

            return dto;
        }
    }
}

