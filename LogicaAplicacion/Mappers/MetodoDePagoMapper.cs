using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;

namespace LogicaAplicacion.Mappers
{
    public class MetodoDePagoMapper
    {
        public static MetodoDePago FromDTO(MetodoDePagoDTO dto)
        {
            return new MetodoDePago
            {
                Metodo = dto.Metodo
            };
        }

        public static MetodoDePagoDTO ToDTO(MetodoDePago entidad)
        {
            return new MetodoDePagoDTO
            {
                Metodo = entidad.Metodo,
            };
        }
    }
}
