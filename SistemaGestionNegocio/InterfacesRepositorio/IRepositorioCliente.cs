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
        public Cliente BuscarPorRazonSocial(string razonSocial);
        List<Cliente> BuscarPorMonto(double monto);
        List<Cliente> ObtenerTodosLosClientes();
        List<Cliente> ObtenerTodosLosClientesConDireccion();
    }
}
