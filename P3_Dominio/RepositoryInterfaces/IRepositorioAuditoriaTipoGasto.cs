using P3_Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3_Dominio.RepositoryInterfaces
{
    public interface IRepositorioAuditoriaTipoGasto : IRepositorio<AuditoriaTipoGasto>
    {
        public IEnumerable<AuditoriaTipoGasto> FindAllPorNombreTipoGasto(String nombre);
    }
}
