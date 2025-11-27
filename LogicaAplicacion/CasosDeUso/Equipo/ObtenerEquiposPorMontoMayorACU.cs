using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesEquipo;
using LogicaAplicacion.Mappers;
using P3_Dominio.Entities; 
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Equipo
{
    public class ObtenerEquiposPorMontoMayorACU : IObtenerEquiposPorMontoMayorA
    {
        private IRepositorioEquipo _repositorioEquipo;
        private IRepositorioPago _repositorioPago;
        public ObtenerEquiposPorMontoMayorACU(IRepositorioEquipo repositorioEquipo, IRepositorioPago repositorioPago)
        {
            _repositorioEquipo = repositorioEquipo;
            _repositorioPago = repositorioPago;
        }

        public IEnumerable<EquipoDTO> ObtenerEquiposPorMontoMayorA(double monto)
        {
            if (monto < 0)
                throw new Exception("El monto debe ser mayor o igual a cero.");

            IEnumerable<P3_Dominio.Entities.Pago> todosLosPagos = _repositorioPago.FindAll();

            IEnumerable<P3_Dominio.Entities.Pago> pagosFiltrados = todosLosPagos
                .Where(p => p is Unico && p.Monto > monto);

            IEnumerable<P3_Dominio.Entities.Equipo> equipos = pagosFiltrados
                .Select(p => p.Usuario.Equipo)
                .Where(e => e != null);

            IEnumerable<P3_Dominio.Entities.Equipo> equiposUnicosYOrdenados = equipos
                .Distinct()                  
                .OrderByDescending(e => e.Nombre);

            IEnumerable<EquipoDTO> equiposDTO = equiposUnicosYOrdenados
                .Select(e => EquipoMapper.ToDTO(e))
                .ToList();

            return equiposDTO;
        }

    }
}

