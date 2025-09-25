using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.Exceptions;

namespace P3_Dominio.ValueObjects.Tipo_GastoVO
{
    [Owned]
    public class NombreGasto
    {
        public string Nombre {  get; private set; }
        public NombreGasto()
        {
            this.Nombre = "Indefinido.";
        }

        public NombreGasto(string nombre)
        {
            this.Nombre = nombre;
        }

        public void Validar()
        {
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if(string.IsNullOrEmpty(this.Nombre) || this.Nombre.Length < 2)
            {
                throw new TipoGastoException("Nombre no puede ser vacío ni tener longitud menor a 2 caracteres.");
            } 
        }
    }
}
