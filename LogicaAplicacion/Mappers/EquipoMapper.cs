using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;

namespace LogicaAplicacion.Mappers
{
    public class EquipoMapper
    {
        public static Equipo FromDTO(EquipoDTO dto)
        {
            return new Equipo
            {
              Id = dto.Id,
              Nombre = dto.Nombre,
            };
        }

        public static EquipoDTO ToDTO(Equipo entidad)
        {
            if (entidad == null) return null;
            return new EquipoDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
            };
        }
    }
}
