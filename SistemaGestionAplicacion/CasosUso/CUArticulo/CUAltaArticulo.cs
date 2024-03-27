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
    public class CUAltaArticulo : ICUAlta<Articulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUAltaArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public void Alta(Articulo nuevo)
        {
            Repo.Alta(nuevo);
        }
    }
}
