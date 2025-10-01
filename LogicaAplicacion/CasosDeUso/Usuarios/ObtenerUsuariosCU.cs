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
    public class ObtenerUsuariosCU : IObtenerUsuarios
    {

        private IRepositorioUsuario _repositorio;

        public ObtenerUsuariosCU(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<UsuarioDTO> ObtenerUsuarios()
        {
            return _repositorio.FindAll().
                Select(
                user => UsuarioMapper.ToDTO(user)
                ).ToList();
        }
    }
}
