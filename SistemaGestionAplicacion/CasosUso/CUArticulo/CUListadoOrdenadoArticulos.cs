using DTOs.DTOs_Articulo;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUArticulo
{
    public class CUListadoOrdenadoArticulos : ICUListadoOrdenadoArticulos
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUListadoOrdenadoArticulos(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public List<DTOAltaArticulo> ListadoOrdenado()
        {
            return MapperArticulo.toListaDTOAltaArticulo(Repo.ListadoOrdenado());
        }
    }
}
