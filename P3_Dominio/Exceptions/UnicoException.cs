using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Exceptions
{
    public class UnicoException : Exception
    {
        public UnicoException() : base() { }
        public UnicoException(string mensaje)
        : base(mensaje) { }
        public UnicoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
