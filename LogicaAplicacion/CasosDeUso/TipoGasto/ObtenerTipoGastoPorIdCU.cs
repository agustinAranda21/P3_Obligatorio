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
    public class ObtenerTipoGastoPorIdCU : IObtenerTipoGastoPorId
    {
        private IRepositorioTipoGasto _repo;

        public ObtenerTipoGastoPorIdCU(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public TipoGastoDTO ObtenerPorId(int id)
        {
            TipoGastoDTO t = TipoGastoMapper.ToDTO(_repo.FindById(id));
            return t;
        }
    }
}
