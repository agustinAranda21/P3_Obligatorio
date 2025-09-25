using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.Exceptions;

namespace P3_Dominio.ValueObjects.UsuarioVO
{
    [Owned]
    public class Password
    {
        public string Clave { get; private set; }

        public Password() { }

        public Password(string clave)
        {
            this.Clave = clave;
        }

        public void Validar()
        {
            ValidarClave();
        }

        private void ValidarClave()
        {
            if(string.IsNullOrEmpty(this.Clave) || this.Clave.Length < 6)
            {
                throw new UsuarioException("El campo clave no puede estar vacío.");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is Password unaP && unaP.Clave == Clave;
        }

    }
}
