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

namespace LogicaAplicacion.CasosDeUso.Pagos
{
    public class ObtenerPagosPorUsuarioCU : IObtenerPagosPorUsuario
    {
        private IRepositorioPago _repoPagos;

        public ObtenerPagosPorUsuarioCU(IRepositorioPago repoPagos)
        {
            _repoPagos = repoPagos;
        }

        public List<PagoDTO> ObtenerPorUsuario(int idUsuario)
        {
            if (idUsuario <= 0 || idUsuario == null)
                throw new ArgumentException("El id del usuario debe ser mayor que 0.");

            List<P3_Dominio.Entities.Pago> pagos = _repoPagos.ObtenerPagosPorUsuario(idUsuario);

            List<PagoDTO> lista = new List<PagoDTO>();

            foreach (P3_Dominio.Entities.Pago p in pagos)
            {
                if (p is Unico pagoUnico)
                {
                    PagoDTO dtoUnico = UnicoMapper.ToDTO(pagoUnico);
                    lista.Add(dtoUnico);
                }
                else if (p is Recurrente pagoRecurrente)
                {
                    PagoDTO dtoRecurrente = RecurrenteMapper.ToDTO(pagoRecurrente);
                    lista.Add(dtoRecurrente);
                }
                else
                {
                    throw new InvalidOperationException("Tipo de pago no reconocido.");
                }
            }

            return lista;
        }
    }
}