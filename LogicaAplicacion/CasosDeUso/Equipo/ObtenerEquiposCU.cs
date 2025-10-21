using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesEquipo;
using LogicaAplicacion.Mappers;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Equipo
{
    public class ObtenerEquiposCU : IObtenerEquipos
    {
        private IRepositorioEquipo _repositorio;

        public ObtenerEquiposCU(IRepositorioEquipo repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<EquipoDTO> ObtenerEquipos()
        {
            return _repositorio.FindAll().Select(equipo => EquipoMapper.ToDTO(equipo)).ToList();
        }
    }
}

