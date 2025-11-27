using LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.InterfacesEquipo
{
    public interface IObtenerEquiposPorMontoMayorA
    {
        public IEnumerable<EquipoDTO> ObtenerEquiposPorMontoMayorA(double monto);
    }
}
