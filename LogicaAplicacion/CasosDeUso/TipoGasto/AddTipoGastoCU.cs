using LogicaAplicacion.DTOs;
using LogicaAplicacion.Mappers;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P3_Dominio.Entities;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;

namespace LogicaAplicacion.CasosDeUso.TipoGasto
{
    public class AddTipoGastoCU : IAddTipoGasto
    {
        private IRepositorioTipoGasto _repo;

        public AddTipoGastoCU(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public void Add(TipoGastoDTO unDto)
        {
            P3_Dominio.Entities.TipoGasto tipoGastoMapeado = TipoGastoMapper.FromDTO(unDto);
            _repo.Add(tipoGastoMapeado);
        } 

        
    }
}
