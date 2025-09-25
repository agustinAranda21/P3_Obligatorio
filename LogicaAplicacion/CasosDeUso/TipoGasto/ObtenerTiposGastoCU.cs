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
    public class ObtenerTiposGastoCU : IObtenerTiposGasto
    {
        private IRepositorioTipoGasto _repo;
        
        public ObtenerTiposGastoCU(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public IEnumerable<TipoGastoDTO> FindAll()
        {
            List<TipoGastoDTO> listaDTO = new List<TipoGastoDTO>();
            foreach (P3_Dominio.Entities.TipoGasto unTipo in _repo.FindAll())
            {
                listaDTO.Add(TipoGastoMapper.ToDTO(unTipo));
            }
            return listaDTO;
        }
    }
}
