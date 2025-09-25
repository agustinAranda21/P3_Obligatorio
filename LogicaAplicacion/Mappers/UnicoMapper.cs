using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;

namespace LogicaAplicacion.Mappers
{
    public class UnicoMapper
    {
        public static Unico FromDTO(UnicoDTO dto)
        {
            return new Unico
            {
                Id = dto.Id,
                MetodoDePago = MetodoDePagoMapper.FromDTO(dto.MetodoDePago),
                TipoGasto = TipoGastoMapper.FromDTO(dto.TipoGasto),
                Usuario = UsuarioMapper.FromDTO(dto.Usuario),
                Descripcion = dto.Descripcion,
                Monto = dto.Monto,
                FechaDePago = dto.FechaDePago,
                NumeroDeRecibo = dto.NumeroDeRecibo
            };
        }

        public static UnicoDTO ToDTO(Unico entidad)
        {
            return new UnicoDTO
            {
                Id = entidad.Id,
                MetodoDePago = MetodoDePagoMapper.ToDTO(entidad.MetodoDePago),
                TipoGasto = TipoGastoMapper.ToDTO(entidad.TipoGasto),
                Usuario = UsuarioMapper.ToDTO(entidad.Usuario),
                Descripcion = entidad.Descripcion,
                Monto = entidad.Monto,
                FechaDePago = entidad.FechaDePago,
                NumeroDeRecibo = entidad.NumeroDeRecibo
            };
        }
    }
}
