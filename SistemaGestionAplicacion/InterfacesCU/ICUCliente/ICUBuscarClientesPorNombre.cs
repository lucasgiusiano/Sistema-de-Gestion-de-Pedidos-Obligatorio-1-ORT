using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUCliente
{
    public interface ICUBuscarClientesPorNombre
    {
        List<Cliente> BuscarClientesPorNOA(string nombreOApellido);
    }
}
