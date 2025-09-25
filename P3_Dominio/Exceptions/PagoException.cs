using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Exceptions
{
   public class PagoException : Exception
    {
        public PagoException() : base() { }
        public PagoException(string mensaje)
        : base(mensaje) { }
        public PagoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
