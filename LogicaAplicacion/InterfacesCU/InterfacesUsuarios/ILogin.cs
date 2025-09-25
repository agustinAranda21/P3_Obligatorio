using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;

namespace LogicaAplicacion.InterfacesCU.InterfacesUsuarios
{
    public interface ILogin
    {
        public UsuarioDTO Login(string email, string password);
    }
}
