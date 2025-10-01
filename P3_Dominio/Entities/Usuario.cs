using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.Interfaces;
using P3_Dominio.ValueObjects.UsuarioVO;

namespace P3_Dominio.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre no puede estar vacío.")]
        public NombrePersona NombreCompleto { get; set; }
        [Required(ErrorMessage = "El campo contraseña no puede estar vacío.")]
        public Password PasswordValidada { get; set; }
        [Required(ErrorMessage = "El campo email no puede estar vacío.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido. Asegurate de que tiene un formato similar a: 'ejemplo@mail.com'")]
        public string Email { get; set; }
        public Rol RolDeUsuario { get; set; }
        public Equipo Equipo { get; set; }

        public Usuario() { }

        public Usuario(int id, NombrePersona nombreCompleto, Password passwordValidada, string email, Rol rolDeUsuario, Equipo equipo)
        {
            this.Id = id;
            this.NombreCompleto = nombreCompleto;
            this.PasswordValidada = passwordValidada;
            this.Email = email;
            this.RolDeUsuario = rolDeUsuario;
            this.Equipo = equipo;
        }

        public Usuario(int id, string nombre, string apellido, string clave, string email, Rol rolDeUsuario, Equipo equipo)
        {
            this.Id= id;
            this.NombreCompleto = new NombrePersona(nombre, apellido);
            this.PasswordValidada = new Password(clave);
            this.Email = email;
            this.RolDeUsuario = rolDeUsuario;
            this.Equipo = equipo;
        }

        public void Validar() { }

        public override bool Equals(object? obj)
        {
            return obj is Usuario unU && unU.Id == Id;
        }

        //public string GenerarEmail(){}
    }
}
