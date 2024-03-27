using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUArticulo
{
    public interface ICUListadoOrdenadoArticulos
    {
        List<Articulo> ListadoOrdenado();
    }
}
