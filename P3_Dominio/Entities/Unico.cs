using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.Entities
{
    public class Unico : Pago
    {
        [Required(ErrorMessage="La fecha de pago es requerida.")]
        public DateTime FechaDePago { get; set; }
        [Required(ErrorMessage = "El número de recibo es requerido.")]
        public string NumeroDeRecibo { get; set; }
        public Unico() { }

        public Unico(int id, MetodoDePago metodoDePago, TipoGasto tipoGasto, Usuario usuario, string descripcion, double monto, DateTime fechaDePago, string numeroDeRecibo) : base(id, metodoDePago, tipoGasto, usuario, descripcion, monto)
        {
            this.FechaDePago = fechaDePago;
            this.NumeroDeRecibo = numeroDeRecibo;
        }

        public override void Validar()
        {
            base.Validar();
        }

        public override double CalcularMontoTotal()
        {
            return this.Monto;
        }
    }
}
