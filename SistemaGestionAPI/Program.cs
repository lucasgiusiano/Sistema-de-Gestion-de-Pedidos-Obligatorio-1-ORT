using DTOs.DTOs_Articulo;
using DTOs.DTOs_Linea;
using DTOs.DTOs_Pedido;
using DTOs.DTOs_Usuario;
using SistemaGestionAplicacion.CasosUso.CUArticulo;
using SistemaGestionAplicacion.CasosUso.CUCliente;
using SistemaGestionAplicacion.CasosUso.CUPedido;
using SistemaGestionAplicacion.CasosUso.CUUsuario;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;
using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionAplicacion.InterfacesCU.ICUUsuario;
using SistemaGestionDatos.Repositorios;
using SistemaGestionNegocio.InterfacesRepositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ICUAltaPedido, CUAltaPedido>();
builder.Services.AddScoped<ICUAnularPedido, CUAnularPedido>();
builder.Services.AddScoped<ICUListarPedidos, CUListarPedidos>();
builder.Services.AddScoped<MapperPedido>();
builder.Services.AddScoped<MapperLinea>();



//Inyecciones de Usuario
builder.Services.AddScoped<ICUAlta<DTOAltaUsuario>, CUAltaUsuario>();
builder.Services.AddScoped<ICUBaja, CUBajaUsuario>();
builder.Services.AddScoped<ICUBuscar<DTOAltaUsuario>, CUBuscarUsuario>();
builder.Services.AddScoped<ICUListado<DTOAltaUsuario>, CUListadoUsuario>();
builder.Services.AddScoped<ICUModificar<DTOAltaUsuario>, CUModificarUsuario>();
builder.Services.AddScoped<ICUBuscarXEmail, CUBuscarXEmail>();
builder.Services.AddScoped<ICUValidarLogin, CUValidarLogin>();

//Inyecciones de Articulo
builder.Services.AddScoped<ICUAlta<DTOAltaArticulo>, CUAltaArticulo>();
builder.Services.AddScoped<ICUListadoOrdenadoArticulos, CUListadoOrdenadoArticulos>();
builder.Services.AddScoped<ICUModificar<DTOAltaArticulo>, CUModificarArticulo>();
builder.Services.AddScoped<ICUBuscar<DTOAltaArticulo>, CUBuscarArticulo>();

//Inyecciones de Cliente
builder.Services.AddScoped<ICUBuscarClientePorRazonSocial, CUBuscarClientePorRazonSocial>();
builder.Services.AddScoped<ICUBuscarClientesPorMonto, CUBuscarClientesPorMonto>();
builder.Services.AddScoped<ICUObtenerTodosLosClientes, CUObtenerTodosLosClientes>();
builder.Services.AddScoped<ICUObtenerTodosLosClientesConDireccion, CUObtenerTodosLosClientesConDireccion>();


//Inyecciones de Repositorios
builder.Services.AddScoped<IRepositorioDireccion, RepositorioDireccion>();
builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
builder.Services.AddScoped<IRepositorioConfiguracion, RepositorioConfiguracion>();

builder.Services.AddDbContext<SistemaGestionContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
