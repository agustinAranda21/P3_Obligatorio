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
    public class NombrePersona
    {
        public string Nombre {  get; private set; }
        public string Apellido { get; private set; }

        public NombrePersona()
        {
            this.Nombre = "Jhon";
            this.Apellido = "Doe";
        }
        
        public NombrePersona(string nombre, string apellido)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

        public void Validar()
        {
            NombreValidado();
            ApellidoValidado();
        }

        private void NombreValidado()
        {
            if (string.IsNullOrEmpty(this.Nombre) || this.Nombre.Length < 2)
            {
                throw new UsuarioException("El campo nombre no puede estar vacío.");
            }
        }

        private void ApellidoValidado()
        {
            if(string.IsNullOrEmpty(this.Apellido) || this.Apellido.Length < 2)
            {
                throw new UsuarioException("El campo apellido no puede estar vacío.");
            }
        }
    }
}
