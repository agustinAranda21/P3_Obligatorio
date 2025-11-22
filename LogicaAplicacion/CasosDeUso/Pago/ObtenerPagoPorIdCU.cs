using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.Mappers;
using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.Pago
{
    public class ObtenerPagoPorIdCU :IObtenerPagoPorId
    {
        private IRepositorioPago _repo;

        public ObtenerPagoPorIdCU(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public PagoDTO ObtenerPorId(int id)
        {
            P3_Dominio.Entities.Pago pago = _repo.FindById(id);

            
            if (pago == null)
            {
                return null;
            }

            if (pago is Unico pagoUnico)
            {
                return UnicoMapper.ToDTO(pagoUnico);
            }
            else if (pago is Recurrente pagoRecurrente)
            {
                return RecurrenteMapper.ToDTO(pagoRecurrente);
            }
            
            throw new InvalidOperationException("Tipo de pago no reconocido");
        }
    }
}
