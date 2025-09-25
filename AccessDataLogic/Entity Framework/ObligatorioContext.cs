using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.Entities;

namespace AccessDataLogic.Entity_Framework
{
    public class ObligatorioContext : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Equipo> equipos { get; set; }
        public DbSet<TipoGasto> tipoGastos { get; set; }
        public DbSet<AuditoriaTipoGasto> auditoriasTipoGastos { get; set; }
        public DbSet<Pago> pagos { get; set; }
        public DbSet<Recurrente> recurrentes { get; set; }
        public DbSet<Unico> unicos { get; set; }

        public ObligatorioContext(DbContextOptions<ObligatorioContext> options)
    : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  Esto es lo que hace que MetodoDePago sea un tipo "embebido"
            modelBuilder.Entity<Pago>().OwnsOne(p => p.MetodoDePago);
        }
    }

}

