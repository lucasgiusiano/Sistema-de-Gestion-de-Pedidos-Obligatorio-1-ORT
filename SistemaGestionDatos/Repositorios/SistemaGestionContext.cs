using Microsoft.EntityFrameworkCore;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;

namespace SistemaGestionDatos.Repositorios
{
    public class SistemaGestionContext: DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            if (!optionsBuilder.IsConfigured) //se comprueba si la base de datos ya esta configurada.
            {
                try
                {
                    base.OnConfiguring(optionsBuilder);
                    optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLOCALDB; Initial Catalog = SistemaGestionPedidos; Integrated Security=SSPI;");
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Error al configurar la base de datos: " + ex.Message);
                    
                    throw new DatabaseConfigurationException("Error al configurar la base de datos.", ex);
                }
            }

        }
    }
}
