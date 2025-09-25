using LogicaAplicacion.DTOs;
using P3_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.InterfacesTipoGasto
{
    public interface IObtenerTiposGasto
    {
        public IEnumerable<TipoGastoDTO> FindAll();
    }
}
