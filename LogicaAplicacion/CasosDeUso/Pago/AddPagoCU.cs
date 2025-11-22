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
    public class AddPagoCU : IAddPago
    {
        private IRepositorioPago _repo;

        public AddPagoCU(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public void Add(PagoDTO unPago)
        {
            if (unPago is UnicoDTO u)
            {
                P3_Dominio.Entities.Unico unico = UnicoMapper.FromDTO(u);
                _repo.Add(unico);
                unPago.Id = unico.Id;
            }
            else if (unPago is RecurrenteDTO r)
            {
                P3_Dominio.Entities.Recurrente rec = RecurrenteMapper.FromDTO(r);
                _repo.Add(rec);
                unPago.Id = rec.Id;
            }
            else
            {
                throw new ArgumentException("Tipo de pago no soportado.");

            }
        }
    }
}
