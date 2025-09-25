using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Exceptions;
using P3_Dominio.Interfaces;

namespace LogicaAplicacion.DTOs
{
    public class TipoGastoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(50, MinimumLength = 10)]
        public string Descripcion { get; set; }

    }
}
