using LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.InterfacesUsuarios
{
    public interface IObtenerUsuarios
    {
        public IEnumerable<UsuarioDTO> ObtenerUsuarios();
    }
}
