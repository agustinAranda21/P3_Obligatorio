using LogicaAplicacion.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.InterfacesCU.InterfacesPago
{
    public interface IObtenerPagosPorUsuario
    {
        List<PagoDTO> ObtenerPorUsuario(int idUsuario);
    }
}