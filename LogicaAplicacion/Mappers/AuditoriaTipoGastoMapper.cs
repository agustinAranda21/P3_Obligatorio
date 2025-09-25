using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class AuditoriaTipoGastoMapper
    {
        public static AuditoriaTipoGasto FromDTO(AuditoriaTipoGastoDTO dto)
        {
            return new AuditoriaTipoGasto
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Accion = dto.Accion,
                Fecha = dto.Fecha,
                Usuario = dto.Usuario
            };
        }

        public static AuditoriaTipoGastoDTO ToDTO(AuditoriaTipoGasto entidad)
        {
            return new AuditoriaTipoGastoDTO
            {
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Descripcion = entidad.Descripcion,
                Accion = entidad.Accion,
                Fecha = entidad.Fecha,
                Usuario = entidad.Usuario
            };
        }
    }
}
