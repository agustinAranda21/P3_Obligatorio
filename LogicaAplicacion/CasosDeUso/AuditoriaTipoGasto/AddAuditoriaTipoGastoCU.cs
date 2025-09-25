using LogicaAplicacion.DTOs;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.Mappers;
using Microsoft.Win32;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.AuditoriaTipoGasto
{
    public class AddAuditoriaTipoGastoCU : IAddAuditoriaTipoGasto
    {
        private IRepositorioAuditoriaTipoGasto _repo;
        public AddAuditoriaTipoGastoCU(IRepositorioAuditoriaTipoGasto repo)
        {
            _repo = repo;
        }   

        public void Add(AuditoriaTipoGastoDTO dto)
        {
            P3_Dominio.Entities.AuditoriaTipoGasto auditoria = AuditoriaTipoGastoMapper.FromDTO(dto);
            _repo.Add(auditoria);
        }
    }
}
