using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioArticulo : IRepositorioArticulo
    {
        public SistemaGestionContext DBContext { get; set; }

        public RepositorioArticulo(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }

        public void Alta(Articulo nuevo)
        {
            if (nuevo != null)
            {
                nuevo.Validar();
                DBContext.Articulos.Add(nuevo);
                DBContext.SaveChanges();
            }
        }

        public List<Articulo> ListadoOrdenado()
        {
            return DBContext.Articulos.OrderBy(a => a.Nombre).ToList();
        }
    }
}
