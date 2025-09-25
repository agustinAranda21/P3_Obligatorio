using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class UnicoDTO : PagoDTO
    {
        [Required(ErrorMessage = "La fecha de pago es requerida.")]
        public DateTime FechaDePago { get; set; }
        [Required(ErrorMessage = "El número de recibo es requerido.")]
        public string NumeroDeRecibo { get; set; }
        
    }
}
