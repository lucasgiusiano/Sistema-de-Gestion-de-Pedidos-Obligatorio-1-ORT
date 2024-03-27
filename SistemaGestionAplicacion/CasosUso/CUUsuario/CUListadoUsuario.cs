using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUUsuario
{
    public class CUListadoUsuario : ICUListado<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUListadoUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public List<Usuario> ObtenerListado()
        {
            return Repo.ObtenerListado();
        }
    }
}
