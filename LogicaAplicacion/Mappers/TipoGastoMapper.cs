using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;
using P3_Dominio.ValueObjects.Tipo_GastoVO;

namespace LogicaAplicacion.Mappers
{
    public class TipoGastoMapper
    {
        public static TipoGasto FromDTO(TipoGastoDTO dto)
        {
            return new TipoGasto
            {
                Id = dto.Id,
                Nombre = new NombreGasto(dto.Nombre),
                Descripcion = dto.Descripcion
            };
        }

        public static TipoGastoDTO ToDTO(TipoGasto entidad)
        {
            return new TipoGastoDTO()
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre.Nombre,
                Descripcion = entidad.Descripcion
            };
        }
    }
}
