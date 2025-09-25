using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Exceptions;

namespace LogicaAplicacion.DTOs
{
    public class RecurrenteDTO : PagoDTO
    {
        [Required(ErrorMessage = "La fecha inicial es requerida.")]
        public DateTime Desde { get; set; }
        [Required(ErrorMessage = "La fecha final es requerida.")]
        public DateTime Hasta { get; set; }


    }
}
