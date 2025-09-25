using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using LogicaAplicacion.Mappers;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.TipoGasto
{
    public class EditarTipoGastoCU : IEditarTipoGasto
    {
        private IRepositorioTipoGasto _repo;
        public EditarTipoGastoCU(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public void Update(TipoGastoDTO unTipoGastoDTO)
        {
            P3_Dominio.Entities.TipoGasto unTipoGasto = TipoGastoMapper.FromDTO(unTipoGastoDTO);
            _repo.Update(unTipoGasto);
        }
    }
}
