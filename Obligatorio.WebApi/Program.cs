using AccessDataLogic.Entity_Framework;
using AccessDataLogic.Entity_Framework.Repositorios;
using LogicaAplicacion.CasosDeUso.Pago;
using LogicaAplicacion.CasosDeUso.TipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.RepositoryInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexion con la base de datos
builder.Services.AddDbContext<ObligatorioContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Obligatorio")));

// Inicializacion de repositorios.
builder.Services.AddScoped<IRepositorioPago, RepositorioPagoEF>();
builder.Services.AddScoped<IRepositorioAuditoriaTipoGasto, RepositorioAuditoriaTipoGastoEF>();

// Inicializacion de casos de uso.
builder.Services.AddScoped<IObtenerPagoPorId, ObtenerPagoPorIdCU>();
builder.Services.AddScoped<IAddPago, AddPagoCU>();
builder.Services.AddScoped<IObtenerTipoGastoPorId, ObtenerTipoGastoPorIdCU>();
builder.Services.AddScoped<IObtenerPagos, ObtenerPagosCU>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
