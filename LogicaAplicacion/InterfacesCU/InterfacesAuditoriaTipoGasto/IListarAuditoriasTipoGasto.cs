using LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto
{
    public interface IListarAuditoriasTipoGasto
    {
        public IEnumerable<AuditoriaTipoGastoDTO> ListarTodasLasAuditoriasTipoGasto(TipoGastoDTO dto);
    }
}
