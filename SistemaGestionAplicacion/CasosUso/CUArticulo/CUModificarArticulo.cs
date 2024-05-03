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
    public class CUModificarArticulo : ICUModificar<DTOAltaArticulo>
    {
        public IRepositorioArticulo Repo { get; set; }

        public CUModificarArticulo(IRepositorioArticulo repo)
        {
            Repo = repo;
        }

        public void Modificar(DTOAltaArticulo modificado)
        {
            Repo.Modificar(MapperArticulo.DTOArticuloToArticulo(modificado));
        }
    }
}
