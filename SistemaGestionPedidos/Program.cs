using SistemaGestionNegocio.InterfacesRepositorio;
using SistemaGestionDatos.Repositorios;
using SistemaGestionAplicacion.CasosUso.CUArticulo;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;
using SistemaGestionAplicacion.CasosUso.CUCliente;
using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionAplicacion.CasosUso.CUPedido;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionAplicacion.CasosUso.CUUsuario;
using SistemaGestionAplicacion.InterfacesCU.ICUUsuario;
using DTOs.DTOs_Usuario;
using DTOs.DTOs_Articulo;
using DTOs.DTOs_Pedido;
using DTOs.DTOs_Linea;

namespace SistemaGestionPedidos
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            //Inyecciones de Pedido
            builder.Services.AddScoped<ICUAltaPedido, CUAltaPedido>();
            builder.Services.AddScoped<ICUAnularPedido, CUAnularPedido>();
            builder.Services.AddScoped<ICUListarPedidosNoEntregadosPorFecha, CUListarPedidosNoEntregadosPorFecha>();
            builder.Services.AddScoped<ICUListarPedidosAnulados, CUListarPedidosAnulados>();
            builder.Services.AddScoped<ICUBuscarPedido, CUBuscarPedido>();
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
