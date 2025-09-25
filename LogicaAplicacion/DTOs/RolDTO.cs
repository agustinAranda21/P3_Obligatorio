using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Enums;
using static P3_Dominio.Entities.Rol;

namespace LogicaAplicacion.DTOs
{
    public class RolDTO
    {
        public TipoRolEnum TipoRol { get; set; }
    }
}
