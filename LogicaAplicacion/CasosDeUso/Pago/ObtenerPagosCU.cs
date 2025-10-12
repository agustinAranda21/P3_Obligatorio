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
    public class ObtenerPagosCU : IObtenerPagos
    {
        private IRepositorioPago _repo;
        
        public ObtenerPagosCU(IRepositorioPago repo)
        {
            _repo = repo;
        }

        public IEnumerable<PagoDTO> ObtenerPagos()
        {
           /* List<PagoDTO> listaDTO = new List<PagoDTO>();
            foreach (P3_Dominio.Entities.Pago unPago in _repo.FindAll())
            {
                if(unPago is Unico unico)
                {
                    listaDTO.Add(UnicoMapper.ToDTO(unico));
                } else if(unPago is Recurrente recurrente)
                {
                    listaDTO.Add(RecurrenteMapper.ToDTO(recurrente));
                }
                
            }
            return listaDTO;*/

            List<P3_Dominio.Entities.Pago> pagos = _repo.FindAll().ToList();
            IEnumerable<PagoDTO> unicos = pagos.OfType<Unico>().Select(u => (PagoDTO)UnicoMapper.ToDTO(u));
            IEnumerable<PagoDTO> recurrentes = pagos.OfType<Recurrente>().Select(r => (PagoDTO)RecurrenteMapper.ToDTO(r));
            return unicos.Concat(recurrentes).ToList();
        }
    }
}
