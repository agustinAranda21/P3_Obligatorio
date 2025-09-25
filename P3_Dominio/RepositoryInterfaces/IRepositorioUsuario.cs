using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Entities;
using P3_Dominio.Exceptions;
using P3_Dominio.ValueObjects.UsuarioVO;

namespace P3_Dominio.RepositoryInterfaces
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        public Usuario Login(string email, Password password);
    }
}
