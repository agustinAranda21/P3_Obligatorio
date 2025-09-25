using Microsoft.EntityFrameworkCore.Query;
using P3_Dominio.Entities;
using P3_Dominio.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessDataLogic.Entity_Framework.Repositorios
{
    public class RepositorioTipoGastoEF : IRepositorioTipoGasto
    {
        private ObligatorioContext _context;

        public RepositorioTipoGastoEF(ObligatorioContext context)
        {
            this._context = context;
        }

        public void Add(TipoGasto nuevo)
        {
            _context.tipoGastos.Add(nuevo);
            _context.SaveChanges();
        }

        public IEnumerable<TipoGasto> FindAll()
        {
            return _context.tipoGastos;
        }

        public TipoGasto FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        { 
            TipoGasto? tipoABorrar = _context.tipoGastos.Find(id);
            if(tipoABorrar != null)
            {
                _context.tipoGastos.Remove(tipoABorrar);
                _context.SaveChanges();
            }
           
        }

        public void Update(TipoGasto actualizar)
        {
       
            _context.tipoGastos.Update(actualizar);
            _context.SaveChanges();
        }
    }
}
