using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using LogicaAplicacion.Mappers;
using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class AltaUsuarioCU : IAddUsuario
    {
        private IRepositorioUsuario _repositorio;
        public AltaUsuarioCU(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }

        public void AltaUsuario(UsuarioDTO usuario)
        {
            Usuario nuevo = UsuarioMapper.FromDTO(usuario);
            _repositorio.Add(nuevo);
        }
    }
}
