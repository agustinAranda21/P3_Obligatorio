using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Exceptions;
using P3_Dominio.Interfaces;

namespace P3_Dominio.Entities
{
    public abstract class Pago : IValidable
    {
        public int Id { get; set; }
        public MetodoDePago MetodoDePago { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public Usuario Usuario { get; set; }
        [Required(ErrorMessage="El campo descripción no puede estar vacío.")]
        [StringLength(50, MinimumLength =6)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo monto no puede estar vacío.")]
        public double Monto { get; set; }

        public Pago() { }
        public Pago(int id, MetodoDePago metodoDePago, TipoGasto tipoGasto, Usuario usuario, string descripcion, double monto)
        {
            Id = id;
            MetodoDePago = metodoDePago;
            TipoGasto = tipoGasto;
            Usuario = usuario;
            Descripcion = descripcion;
            Monto = monto;
        }

        public virtual void Validar()
        {
            ValidarMonto();
        }

        protected void ValidarMonto()
        {
            if (this.Monto < 0 )
            {
                throw new PagoException("El monto debe ser un número mayor o igual a cero.");
            }
        }

        public abstract double CalcularMontoTotal();
    }
}
