using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUCliente
{
    public interface ICUObtenerTodosLosClientesConDireccion
    {
        public List<Cliente> ObtenerTodosLosClientesConDireccion();
    }
}
