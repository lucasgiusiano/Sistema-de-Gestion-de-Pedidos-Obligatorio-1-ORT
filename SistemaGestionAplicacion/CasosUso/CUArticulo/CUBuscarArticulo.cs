using DTOs.DTOs_Articulo;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUArticulo
{
    public class CUBuscarArticulo : ICUBuscar<DTOAltaArticulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUBuscarArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public DTOAltaArticulo Buscar(int id)
        {
            return MapperArticulo.toDTOAltaArticulo(Repo.BuscarPorId(id));
        }
    }
}
