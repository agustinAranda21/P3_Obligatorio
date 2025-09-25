using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException() : base() { }
        public UsuarioException(string mensaje)
        : base(mensaje) { }
        public UsuarioException(string mensaje, Exception ex)
        : base(mensaje, ex) { }
    }
}
