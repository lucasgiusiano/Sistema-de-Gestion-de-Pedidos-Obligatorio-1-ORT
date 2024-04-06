using SistemaGestionNegocio;
using SistemaGestionDatos;
using SistemaGestionAplicacion.CasosUso;
using SistemaGestionNegocio.InterfacesRepositorio;
using SistemaGestionDatos.Repositorios;
using SistemaGestionNegocio.Dominio;
using SistemaGestionAplicacion.CasosUso.CUArticulo;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;
using SistemaGestionAplicacion.CasosUso.CUCliente;
using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionAplicacion.CasosUso.CUPedido;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionAplicacion.CasosUso.CUUsuario;




namespace SistemaGestionPedidos
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped <ICUAlta<Articulo>, CUAltaArticulo> ();
            builder.Services.AddScoped<ICUListadoOrdenadoArticulos, CUListadoOrdenadoArticulos>();
            builder.Services.AddScoped<ICUBuscarClientesPorMonto, CUBuscarClientesPorMonto>();
            builder.Services.AddScoped<ICUBuscarClientesPorRazonSocial, CUBuscarClientesPorRazonSocial>();
            builder.Services.AddScoped<ICUAlta<Pedido>, CUAltaPedido>();
            builder.Services.AddScoped<ICUAnularPedido, CUAnularPedido>();
            builder.Services.AddScoped<ICUListadoPedidosAnuladosXFecha, CUListadoPedidosAnuladosXFecha>();
            builder.Services.AddScoped<ICUAlta<Usuario>, CUAltaUsuario>();
            builder.Services.AddScoped<ICUBaja, CUBajaUsuario>();
            builder.Services.AddScoped<ICUBuscar<Usuario>, CUBuscarUsuario>();
            builder.Services.AddScoped<ICUListado<Usuario>, CUListadoUsuario>();
            builder.Services.AddScoped<ICUModificar<Usuario>, CUModificarUsuario>();

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            builder.Services.AddScoped<IRepositorioPedido, RepositorioPedido>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
            
    }

}
