using System.ComponentModel.DataAnnotations;

namespace ObligatorioWebApp.ViewModels
{
    public class AddTipoGastoViewModel
    {
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(50, MinimumLength = 10)]
        public string Descripcion { get; set; }
    }
}
