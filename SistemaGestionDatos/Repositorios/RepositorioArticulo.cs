using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;
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
                if (!DBContext.Articulos.Any(a => a.Nombre.Valor == nuevo.Nombre.Valor))
                {
                    DBContext.Articulos.Add(nuevo);
                    DBContext.SaveChanges();
                }
                else
                {
                    throw new ArticuloValidationException("Ya existe un articulo con ese nombre");
                }
            }
            else
            {
                throw new ArticuloValidationException("El artículo proporcionado es nulo.");
            }
        }

        public void Modificar(Articulo modificado)
        {
            if (modificado != null)
            {
                if (!DBContext.Articulos.Any(a => a.Nombre.Valor == modificado.Nombre.Valor))
                {
                    DBContext.Articulos.Update(modificado);
                    DBContext.SaveChanges();
                }
                else
                {
                    throw new ArticuloValidationException("Ya existe un articulo con ese nombre");
                }
            }
            else
            {
                throw new ArticuloValidationException("Ha ocurrido un error al modificar el articulo (Articulo nulo)");
            }
        }

        public Articulo BuscarPorId(int id)
        {
            return DBContext.Articulos.Where(a => a.Id == id).SingleOrDefault();
        }

        public List<Articulo> ListadoOrdenado()
        {
            return DBContext.Articulos.OrderBy(a => a.Nombre.Valor).ToList();
        }


    }
}
