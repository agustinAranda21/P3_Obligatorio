using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;

namespace LogicaAplicacion.Mappers
{
    public class RolMapper
    {
        public static Rol FromDTO(RolDTO dto)
        {
            return new Rol
            {
                TipoRol = dto.TipoRol
            };
        }

        public static RolDTO ToDTO(Rol entidad)
        {
            return new RolDTO
            {
                TipoRol = entidad.TipoRol
            };
        }
    }
}
