using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;
using P3_Dominio.ValueObjects.UsuarioVO;

namespace LogicaAplicacion.Mappers
{
    public class UsuarioMapper
    {
        public static Usuario FromDTO(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                NombreCompleto = new NombrePersona(dto.Nombre, dto.Apellido),
                PasswordValidada = new Password(dto.Clave),
                Email = dto.Email,
                RolDeUsuario = RolMapper.FromDTO(dto.RolDeUsuario),
                Equipo = EquipoMapper.FromDTO(dto.Equipo)
            };
        }

        public static UsuarioDTO ToDTO(Usuario entidad)
        {
            return new UsuarioDTO
            {
                Id = entidad.Id,
                Nombre = entidad.NombreCompleto.Nombre,
                Apellido = entidad.NombreCompleto.Apellido,
                Clave = entidad.PasswordValidada.Clave,
                Email = entidad.Email,
                RolDeUsuario = RolMapper.ToDTO(entidad.RolDeUsuario),
                Equipo = EquipoMapper.ToDTO(entidad.Equipo)
            };
        }
    }
}
