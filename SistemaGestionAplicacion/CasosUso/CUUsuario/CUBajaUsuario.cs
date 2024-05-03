using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUUsuario
{
    public class CUBajaUsuario : ICUBaja
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBajaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Baja(int id)
        {
            Repo.Baja(id);
        }
    }
}
