using SistemaGestionAplicacion.InterfacesCU.ICUUsuario;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUUsuario
{
    public class CUBuscarXEmail : ICUBuscarXEmail
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUBuscarXEmail(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public Usuario BuscarXEmail(string email)
        {
          return  Repo.BuscarXEmail(email);
        }
    }
}
