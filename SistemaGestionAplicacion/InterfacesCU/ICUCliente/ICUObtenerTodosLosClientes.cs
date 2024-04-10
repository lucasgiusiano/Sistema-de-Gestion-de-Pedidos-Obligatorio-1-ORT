using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUCliente
{
    public interface ICUObtenerTodosLosClientes
    {
        public List<Cliente> ObtenerTodosLosClientes();
        List<Cliente> ObtenerTodosLosClientesConDireccion();
    }
}
