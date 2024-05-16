using DTOs.DTOs_Usuario;
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
    public class CUAltaUsuario : ICUAlta<DTOAltaUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUAltaUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Alta(DTOAltaUsuario nuevo)
        {
            Usuario uNuevo = MapperUsuario.DTOAltaUsuarioToUsuario(nuevo);
            uNuevo.Validar();
			Repo.Alta(uNuevo);
        }
    }
}
