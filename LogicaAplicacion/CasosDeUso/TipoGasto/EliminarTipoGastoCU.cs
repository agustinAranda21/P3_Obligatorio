using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.TipoGasto
{
    public class EliminarTipoGastoCU : IEliminarTipoGasto
    {
        private IRepositorioTipoGasto _repo;
        
        public EliminarTipoGastoCU(IRepositorioTipoGasto repo)
        {
            _repo = repo;
        }

        public void Remove(int id)
        {
            _repo.Remove(id);
        }
    }
}
