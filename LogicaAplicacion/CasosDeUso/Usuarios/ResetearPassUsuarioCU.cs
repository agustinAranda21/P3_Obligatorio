using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using P3_Dominio.ValueObjects.UsuarioVO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class ResetearPassUsuarioCU : IResetearPassUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;

        public ResetearPassUsuarioCU(IRepositorioUsuario repositorioUsuario)
        {
            if (repositorioUsuario == null)
            {
                throw new Exception("repositorioUsuario");
            }
            _repositorioUsuario = repositorioUsuario;
        }

        public string ResetearPass(int idUsuario)
        {
            Usuario usuario = _repositorioUsuario.FindById(idUsuario);
            if (usuario == null)
            {
                throw new ArgumentException("No existe un usuario con ese ID.");
            }
            string generada = GenerarPassAleatoria();
            Password nuevaPass = new Password(generada);
            nuevaPass.Validar();

            usuario.PasswordValidada = nuevaPass;
            _repositorioUsuario.Update(usuario);
            return generada;
        }
    

    private string GenerarPassAleatoria()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            int largo = 8;

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < largo; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }
    }
}
