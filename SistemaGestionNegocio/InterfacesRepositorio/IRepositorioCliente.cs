using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.InterfacesRepositorio
{
    public interface IRepositorioCliente
    {
        List<Cliente> BuscarPorNombreApellido(string nombreOApellido);
        List<Cliente> BuscarPorMonto(double monto);
    }
}
