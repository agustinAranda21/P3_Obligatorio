using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo apellido no puede estar vacío.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo contraseña no puede estar vacío.")]
        public string Clave { get; set; }
        [Required(ErrorMessage = "El campo email no puede estar vacío.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido. Asegurate de que tiene un formato similar a: 'ejemplo@mail.com'")]
        public string Email { get; set; }
        public RolDTO RolDeUsuario { get; set; }
        public EquipoDTO Equipo { get; set; }

    }
}
