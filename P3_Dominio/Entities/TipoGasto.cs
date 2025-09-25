using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Exceptions;
using P3_Dominio.Interfaces;
using P3_Dominio.ValueObjects.Tipo_GastoVO;

namespace P3_Dominio.Entities
{
    public class TipoGasto : IValidable
    {
        public int Id { get; set; }
        public NombreGasto Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(50, MinimumLength = 10)]
        public string Descripcion { get; set; }

        public TipoGasto() { }
        public TipoGasto(NombreGasto nombre, string descripcion)
        {
          
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public TipoGasto(string nombre, string descripcion)
        {
         
            this.Nombre = new NombreGasto(nombre);
            this.Descripcion = descripcion;
        }

        public void Validar()
        {
            try
            {
                this.Nombre.Validar();
            }
            catch (TipoGastoException ex)
            {
                throw new Exception("Tipo de gasto inválido.", ex);
            }
        }

        public override bool Equals(object? obj)
        {
            return (obj is TipoGasto unTP && unTP.Id == Id);
        }

    }
}
