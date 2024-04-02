using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public List<Cliente> BuscarPorMonto(double monto)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> BuscarPorNombreApellido(string nombreOApellido)
        {
            throw new NotImplementedException();
        }
    }
}
