using LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.InterfacesPago
{
    public interface IObtenerPagoPorId
    {
        public PagoDTO ObtenerPorId(int id);
    }
}
