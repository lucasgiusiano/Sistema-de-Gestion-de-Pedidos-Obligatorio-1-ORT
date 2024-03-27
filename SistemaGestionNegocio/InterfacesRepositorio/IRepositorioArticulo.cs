using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.InterfacesRepositorio
{
    public interface IRepositorioArticulo
    {
        void Alta(Articulo nuevo);
        List<Articulo> ListadoOrdenado();
    }
}
