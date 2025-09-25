using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Exceptions;

namespace P3_Dominio.Entities
{
    public class Recurrente : Pago
    {
        [Required(ErrorMessage="La fecha inicial es requerida.")]
        public DateTime Desde { get; set; }
        [Required(ErrorMessage="La fecha final es requerida.")]
        public DateTime Hasta { get; set; }

        public Recurrente() { }

        public Recurrente(int id, MetodoDePago metodoDePago, TipoGasto tipoGasto, Usuario usuario, string descripcion, double monto, DateTime desde, DateTime hasta) : base(id, metodoDePago, tipoGasto, usuario, descripcion, monto)
        {
            this.Desde = desde;
            this.Hasta = hasta;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarFecha();
        }

        private void ValidarFecha()
        {
            if (this.Desde >= this.Hasta || this.Desde > DateTime.Now)
            {
                throw new RecurrenteException("La fecha de inicio no puede ser mayor o igual a la fecha de finalización.");
            }
        }

        public override double CalcularMontoTotal()
        {
                int diferenciaMeses = (this.Hasta.Year - this.Desde.Year) * 12 + (this.Hasta.Month - this.Desde.Month);
                double montoTotal = diferenciaMeses * this.Monto;
                return montoTotal;
        }

    }
}
