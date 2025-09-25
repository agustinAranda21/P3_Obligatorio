using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.Enums;

namespace P3_Dominio.Entities
{
    [Owned]
    public class Rol
    {
        public TipoRolEnum TipoRol { get; set; }
    }
}
