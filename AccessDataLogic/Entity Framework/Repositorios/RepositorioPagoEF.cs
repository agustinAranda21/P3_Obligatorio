
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
    public class RepositorioPagoEF : IRepositorioPago
    {
        private ObligatorioContext _context;
        
        public RepositorioPagoEF(ObligatorioContext context)
        {
            this._context = context;
        }

        public void Add (Pago nuevo)
        {
            try
            {
                nuevo.Validar();
                _context.pagos.Add(nuevo); 
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el pago: " + ex.Message, ex);
            }
        }

        public IEnumerable<Pago> FindAll()
        {
            return _context.pagos
                .Include(u => u.TipoGasto)
                .Include(u => u.Usuario)
                .ThenInclude(u => u.Equipo)
                .ToList();
        }

        public Pago FindById(int id)
        {
            return _context.pagos
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario).ThenInclude(u => u.Equipo)
                .Include(p => p.MetodoDePago)
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pago actualizar)
        {
            throw new NotImplementedException();
        }

        List<Pago> IRepositorioPago.ObtenerPagosPorUsuario(int idUsuario)
        {
            return _context.pagos.Where(p => p.Usuario.Id == idUsuario)
                .Include(p => p.TipoGasto)
                .Include(p => p.Usuario)
                .Include(p => p.MetodoDePago)
                .ToList();
        }
    }
}
