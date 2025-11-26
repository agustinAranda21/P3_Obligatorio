using WebAppClienteHttp.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppClienteHttp.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebAppClienteHttp.ViewModels
{
    public class AddUsuarioViewModel
    {
        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo apellido no puede estar vacío.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo contraseña no puede estar vacío.")]
        public string Password { get; set; }
        public string Email { get; set; }
        public TipoRolEnum TipoRol { get; set; }
        public int EquipoId { get; set; }

        public IEnumerable<EquipoDTO> Equipos { get; set; }
    }

}


