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
    public class CUBuscarUsuario : ICUBuscar<Usuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBuscarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public Usuario Buscar(int id)
        {
            return Repo.BuscarPorId(id);
        }
    }
}
