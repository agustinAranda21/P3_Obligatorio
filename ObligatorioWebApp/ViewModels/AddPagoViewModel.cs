using LogicaAplicacion.DTOs;

namespace ObligatorioWebApp.ViewModels {

public class AddPagoViewModel
{
    public IEnumerable<TipoGastoDTO> TiposGasto { get; set; }
    public IEnumerable<UsuarioDTO> Usuarios { get; set; }
    }

}