using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string email, Password password)
        {
            foreach(Usuario usuario in _context.usuarios)
            {
                if(usuario.Email == email)
                {
                    if(usuario.PasswordValidada.Equals(password))
                    {
                        return usuario;
                    }
                }
            }
            throw new UsuarioException("Email o contraseña incorrectos.");
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario actualizar)
        {
            throw new NotImplementedException();
        }
    }
}
