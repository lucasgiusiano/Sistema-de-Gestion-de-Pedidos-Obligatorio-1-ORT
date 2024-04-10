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
    public class CUModificarArticulo : ICUModificar<Articulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUModificarArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public void Modificar(Articulo modificado)
        {
            Repo.Modificar(modificado);
        }
    }
}
