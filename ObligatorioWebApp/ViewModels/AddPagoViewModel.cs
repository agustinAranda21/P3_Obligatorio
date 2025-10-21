using LogicaAplicacion.DTOs;
using P3_Dominio.Enums;
using System.ComponentModel.DataAnnotations;

namespace ObligatorioWebApp.ViewModels {

public class AddPagoViewModel
{
    public IEnumerable<TipoGastoDTO> TiposGasto { get; set; }
    public IEnumerable<UsuarioDTO> Usuarios { get; set; }
    public MetodoDePagoEnum MetodoDePago { get; set; }
    public int TipoGastoId { get; set; }
    public int UsuarioId { get; set; }
    [Required(ErrorMessage = "El campo descripción no puede estar vacío.")]
    [StringLength(50, MinimumLength = 6)]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "El campo monto no puede estar vacío.")]
    public double Monto { get; set; }
    public double SaldoPendiente { get; set; }
    public DateTime FechaDePago { get; set; }
    public string NumeroDeRecibo { get; set; }
    public DateTime Desde { get; set; }
    public DateTime Hasta { get; set; }


    }

}