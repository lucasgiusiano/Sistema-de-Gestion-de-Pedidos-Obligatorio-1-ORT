using DTOs.DTOs_Articulo;
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
        List<DTOAltaArticulo> ListadoOrdenado();
    }
}
