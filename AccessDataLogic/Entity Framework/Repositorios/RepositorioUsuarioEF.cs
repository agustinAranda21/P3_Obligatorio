using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.Entities;
using P3_Dominio.Exceptions;
using P3_Dominio.RepositoryInterfaces;
using P3_Dominio.ValueObjects.UsuarioVO;

namespace AccessDataLogic.Entity_Framework.Repositorios
{
    public class RepositorioUsuarioEF : IRepositorioUsuario
    {
        private ObligatorioContext _context;

        public RepositorioUsuarioEF(ObligatorioContext context)
        {
            this._context = context;
        }
        public void Add(Usuario nuevo)
        {
            Random random = new Random();
            string numeroAleatorio = random.Next(0, 1000).ToString();

            if (_context.usuarios.Any(u => u.Email == nuevo.Email))
            {
                nuevo.Email += numeroAleatorio;
            }

            nuevo.Validar();
            _context.usuarios.Add(nuevo);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            return _context.usuarios.Include(u => u.Equipo)
                .OrderBy(user => user.NombreCompleto.Apellido)
                .ThenBy(user => user.Id)
                .ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.usuarios
                .Include(u => u.Equipo)
                .FirstOrDefault(u => u.Id == id);
        }

        public Usuario Login(string email, Password password)
        {
            Usuario logueado = _context.usuarios.Where(
                user =>
                user.Email == email &&
                user.PasswordValidada.Clave == password.Clave
                ).FirstOrDefault();
            if (logueado == null)
            {
                throw new UsuarioException("Email o contraseña incorrectos.");
            }
            return logueado;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario actualizar)
        {
            try
            {
                actualizar.Validar();
                _context.usuarios.Update(actualizar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: " + ex.Message, ex);
            }
        }
    }
}
