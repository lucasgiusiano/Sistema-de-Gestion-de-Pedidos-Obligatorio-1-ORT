using DTOs.DTOs_de_Cliente;
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
    public class CUValidarLogin : ICUValidarLogin
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUValidarLogin(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public DTOLoginUsuario ValidarLogin(DTOLoginUsuario dTOLoginUsuario)
        {
            return MapperUsuario.toDTOLoginUsuario(Repo.ValidarLogin(dTOLoginUsuario.Email, dTOLoginUsuario.Contra));
        }
    }
}
