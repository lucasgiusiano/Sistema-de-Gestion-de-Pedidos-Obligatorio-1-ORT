using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUUsuario
{
    public interface ICUValidarLogin
    {
        Usuario ValidarLogin(string email, string contrasenia);
    }
}
