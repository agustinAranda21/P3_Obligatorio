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
    public abstract class PagoDTO
    {
        public int Id { get; set; }
        public MetodoDePagoDTO MetodoDePago { get; set; }
        public TipoGastoDTO TipoGasto { get; set; }
        public UsuarioDTO Usuario { get; set; }
        [Required(ErrorMessage = "El campo descripción no puede estar vacío.")]
        [StringLength(50, MinimumLength = 6)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo monto no puede estar vacío.")]
        public double Monto { get; set; }
    }
}
