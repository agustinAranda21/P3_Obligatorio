using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using LogicaAplicacion.Mappers;
using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using P3_Dominio.ValueObjects.UsuarioVO;

namespace LogicaAplicacion.CasosDeUso.Usuarios
{
    public class LoginCU : ILogin
    {
        private IRepositorioUsuario _repositorio;

        public LoginCU(IRepositorioUsuario repositorio)
        {
            _repositorio = repositorio;
        }
        public UsuarioDTO Login(string email, string password)
        {
            Usuario logueado = this._repositorio.Login(email, new Password(password));
            UsuarioDTO toReturn = UsuarioMapper.ToDTO(logueado);
            return toReturn;
        }
    }
}