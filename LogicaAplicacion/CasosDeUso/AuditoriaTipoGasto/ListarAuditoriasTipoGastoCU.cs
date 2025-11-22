
using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.Mappers;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.AuditoriaTipoGasto
{
    public class ListarAuditoriasTipoGastoCU : IListarAuditoriasTipoGasto
    {
        private IRepositorioAuditoriaTipoGasto _repo;

        public ListarAuditoriasTipoGastoCU(IRepositorioAuditoriaTipoGasto repo)
        {
            this._repo = repo;
        }

        public IEnumerable<AuditoriaTipoGastoDTO> ListarTodasLasAuditoriasTipoGasto(TipoGastoDTO dto)
        {
            String nombreTipoGasto = dto.Nombre;
            List<P3_Dominio.Entities.AuditoriaTipoGasto> lista = _repo.FindAllPorNombreTipoGasto(nombreTipoGasto);
            List<AuditoriaTipoGasto>
        }
        {

        }
    }
}
