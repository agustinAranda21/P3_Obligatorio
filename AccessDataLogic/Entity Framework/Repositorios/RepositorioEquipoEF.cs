using Microsoft.EntityFrameworkCore;
using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLogic.Entity_Framework.Repositorios
{
    public class RepositorioEquipoEF : IRepositorioEquipo
    {
        private ObligatorioContext _context;

        public RepositorioEquipoEF(ObligatorioContext context)
        {
            this._context = context;
        }
        public void Add(Equipo nuevo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipo> FindAll()
        {
            return _context.equipos.ToList();
        }

        public Equipo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Equipo actualizar)
        {
            throw new NotImplementedException();
        }
    }
}
