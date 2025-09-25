using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLogic.Entity_Framework.Repositorios
{
    public class RepositorioAuditoriaTipoGastoEF : IRepositorioAuditoriaTipoGasto
    {
        private ObligatorioContext _context;

        public RepositorioAuditoriaTipoGastoEF(ObligatorioContext context)
        {
            this._context = context;
        }

        public void Add(AuditoriaTipoGasto nuevo)
        {
            _context.auditoriasTipoGastos.Add(nuevo);
            _context.SaveChanges();
        }

        public IEnumerable<AuditoriaTipoGasto> FindAll()
        {
            throw new NotImplementedException();
        }

        public AuditoriaTipoGasto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AuditoriaTipoGasto actualizar)
        {
            throw new NotImplementedException();
        }
    }
}
