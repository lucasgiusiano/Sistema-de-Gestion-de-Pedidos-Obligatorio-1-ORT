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
        public SistemaGestionContext DBContext { get; set; }

        public RepositorioCliente(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }

        public List<Cliente> BuscarPorMonto(double monto)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> BuscarPorRazonSocial(string razonSocial)
        {
            throw new NotImplementedException();
        }
    }
}
