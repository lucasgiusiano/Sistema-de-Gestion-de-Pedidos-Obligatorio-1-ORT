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
    public class CUAltaArticulo : ICUAlta<DTOAltaArticulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUAltaArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public void Alta(DTOAltaArticulo nuevo)
        {
            Repo.Alta(MapperArticulo.DTOArticuloToArticulo(nuevo));
        }
    }
}
