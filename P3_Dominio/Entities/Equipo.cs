using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Interfaces;

namespace P3_Dominio.Entities
{
   public class Equipo : IValidable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del equipo es requerido.")]
        public string Nombre { get; set; }

        public Equipo() { }

        public Equipo(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }

        public void Validar() { }
    }
}
