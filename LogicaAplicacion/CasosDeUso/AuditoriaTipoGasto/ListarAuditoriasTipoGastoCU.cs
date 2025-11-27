
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

        public IEnumerable<AuditoriaTipoGastoDTO> ListarTodasLasAuditoriasTipoGasto(int id)
        {
            IEnumerable<P3_Dominio.Entities.AuditoriaTipoGasto> lista = _repo.FindAllByIdTipoGasto(id);
            return lista.Select(a => AuditoriaTipoGastoMapper.ToDTO(a));
        }
    }
}
