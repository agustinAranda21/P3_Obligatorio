using AccessDataLogic.Entity_Framework;
using AccessDataLogic.Entity_Framework.Repositorios;
using LogicaAplicacion.CasosDeUso.AuditoriaTipoGasto;
using LogicaAplicacion.CasosDeUso.TipoGasto;
using LogicaAplicacion.CasosDeUso.Usuarios;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.RepositoryInterfaces;

namespace ObligatorioWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            // Conexion con la base de datos
            builder.Services.AddDbContext<ObligatorioContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("Obligatorio")));

            //Inicializacion de repositorios
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
            builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGastoEF>();
            builder.Services.AddScoped<IRepositorioAuditoriaTipoGasto, RepositorioAuditoriaTipoGastoEF>();
   

            //Inicializacion de casos de uso
            builder.Services.AddScoped<ILogin, LoginCU>();
            builder.Services.AddScoped<IAddTipoGasto, AddTipoGastoCU>();
            builder.Services.AddScoped<IEliminarTipoGasto, EliminarTipoGastoCU>();
            builder.Services.AddScoped<IObtenerTiposGasto, ObtenerTiposGastoCU>();
            builder.Services.AddScoped<IEditarTipoGasto, EditarTipoGastoCU>();
            builder.Services.AddScoped<IAddAuditoriaTipoGasto, AddAuditoriaTipoGastoCU>();
            builder.Services.AddScoped<IObtenerUsuarios, ObtenerUsuariosCU>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
