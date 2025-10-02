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
                    TipoDeGastoId = dto.TipoDeGastoId,
                    UsuarioId = usuarioId,
                    FechaPago = dto.FechaPago,
                    NumFactura = dto.NumFactura
            };
              
            }
            else if (dto.TipoDePago == TipoDePago.Recurrente)
            {
                return new PagoRecurrente
                {
                    Id = dto.Id,
                    MetodoDePago = dto.MetodoDePago,
                    Descripcion = dto.Descripcion,
                    TipoDeGastoId = dto.TipoDeGastoId,
                    MontoTotal = dto.MontoTotal,
                    UsuarioId = usuarioId,
                    FechaDesde = dto.FechaDesde,
                    FechaHasta = dto.FechaHasta
                };
            }
            else
            {
                throw new ArgumentException("Tipo de pago no soportado");
            }

        }

        public static PagoDTO ToDTO(Pago entity)
        {
            PagoDTO dto = new PagoDTO
            {
                Id = entity.Id,
                MetodoDePago = entity.MetodoDePago,
                Descripcion = entity.Descripcion,
                MontoTotal = entity.MontoTotal,
                UsuarioId = entity.UsuarioId,
                TipoDeGastoId = entity.TipoDeGastoId,
            };

            if (entity is PagoUnico pu)
            {
                
                dto.FechaPago = pu.FechaPago;
                dto.NumFactura = pu.NumFactura;
            }
            else if (entity is PagoRecurrente pr)
            {
                dto.FechaDesde = pr.FechaDesde;
                dto.FechaHasta = pr.FechaHasta;
            }

            return dto;
        }
    }
}

