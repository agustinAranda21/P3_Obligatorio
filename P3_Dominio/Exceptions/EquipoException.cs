using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Exceptions
{
    public class EquipoException : Exception
    {
        public EquipoException() : base() { }
        public EquipoException(string mensaje)
        : base(mensaje) { }
        public EquipoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
