using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Exceptions
{
    public class TipoGastoException : Exception 
    {
        public TipoGastoException() : base() { }
        public TipoGastoException(string mensaje)
        : base(mensaje) { }
        public TipoGastoException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
