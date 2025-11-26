using AccessDataLogic.Entity_Framework;
using AccessDataLogic.Entity_Framework.Repositorios;
using LogicaAplicacion.CasosDeUso.AuditoriaTipoGasto;
using LogicaAplicacion.CasosDeUso.Pago;
using LogicaAplicacion.CasosDeUso.TipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesAuditoriaTipoGasto;
using LogicaAplicacion.InterfacesCU.InterfacesPago;
using LogicaAplicacion.InterfacesCU.InterfacesTipoGasto;
using Microsoft.EntityFrameworkCore;
using P3_Dominio.RepositoryInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using LogicaAplicacion.InterfacesCU.InterfacesUsuarios;
using LogicaAplicacion.CasosDeUso.Usuarios;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

//JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) 
    .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = new TokenValidationParameters()
         {
             ValidateIssuerSigningKey = true,
             IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection(
                 "SecretTokenKey").Value!)),
             ValidateIssuer = false,
             ValidateAudience = false,
         };
     });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( opciones =>
    {
    opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
    {
        Description = "Autorizacion estándar mediante esquema Bearer",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opciones.OperationFilter<SecurityRequirementsOperationFilter>();
    opciones.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Documentación de api",
        Description = "Aquí se encuentran todos los endpoints activos para utilizar los servicios del obligatorio.",
        Contact = new OpenApiContact
        {
            Email = "ShiMiy@laEmpresa.com"
        },
        Version = "v1"
    });
}
    );

// Conexion con la base de datos
builder.Services.AddDbContext<ObligatorioContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Obligatorio")));

// Inicializacion de repositorios.
builder.Services.AddScoped<IRepositorioPago, RepositorioPagoEF>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioAuditoriaTipoGasto, RepositorioAuditoriaTipoGastoEF>();
builder.Services.AddScoped<IRepositorioTipoGasto, RepositorioTipoGastoEF>();


// Inicializacion de casos de uso.
builder.Services.AddScoped<IObtenerPagoPorId, ObtenerPagoPorIdCU>();
builder.Services.AddScoped<IAddPago, AddPagoCU>();
builder.Services.AddScoped<IObtenerPagos, ObtenerPagosCU>();
builder.Services.AddScoped<ILogin, LoginCU>();
builder.Services.AddScoped<IListarAuditoriasTipoGasto, ListarAuditoriasTipoGastoCU>();
builder.Services.AddScoped<IObtenerTiposGasto, ObtenerTiposGastoCU>();
builder.Services.AddScoped<IObtenerUsuarios, ObtenerUsuariosCU>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
