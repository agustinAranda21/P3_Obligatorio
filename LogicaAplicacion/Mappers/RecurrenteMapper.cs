using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;

namespace LogicaAplicacion.Mappers
{
    public class RecurrenteMapper
    {
        public static Recurrente FromDTO(RecurrenteDTO dto)
        {
            return new Recurrente
            {
                Id = dto.Id,
                MetodoDePago = MetodoDePagoMapper.FromDTO(dto.MetodoDePago),
                TipoGastoId = dto.TipoGastoId,
                UsuarioId = dto.UsuarioId,
                Descripcion = dto.Descripcion,
                Monto = dto.Monto,
                SaldoPendiente = dto.SaldoPendiente,
                Desde = dto.Desde,
                Hasta = dto.Hasta
            };
        }
        
        public static RecurrenteDTO ToDTO(Recurrente entidad)
        {
            return new RecurrenteDTO
            {
                Id = entidad.Id,
                MetodoDePago = MetodoDePagoMapper.ToDTO(entidad.MetodoDePago),
                TipoGasto = TipoGastoMapper.ToDTO(entidad.TipoGasto),
                Usuario = UsuarioMapper.ToDTO(entidad.Usuario),
                Descripcion = entidad.Descripcion,
                Monto = entidad.Monto,
                SaldoPendiente = entidad.SaldoPendiente,
                Desde = entidad.Desde,
                Hasta = entidad.Hasta
            };
        }
    }
}
