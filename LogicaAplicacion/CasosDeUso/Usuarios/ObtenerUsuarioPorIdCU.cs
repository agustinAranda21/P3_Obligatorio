using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using LogicaAplicacion.Mappers;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class ObtenerUsuarioPorIdCU : IObtenerUsuarioPorId
    {
        private IRepositorioUsuario _repo;

        public ObtenerUsuarioPorIdCU(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public UsuarioDTO ObtenerPorId(int id)
        {
            UsuarioDTO u = UsuarioMapper.ToDTO(_repo.FindById(id));
            return u;
        }
    }
}
