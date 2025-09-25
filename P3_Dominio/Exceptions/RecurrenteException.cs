using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Exceptions
{
    public class RecurrenteException : Exception
    {
        public RecurrenteException() : base() { }
        public RecurrenteException(string mensaje)
        : base(mensaje) { }
        public RecurrenteException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
