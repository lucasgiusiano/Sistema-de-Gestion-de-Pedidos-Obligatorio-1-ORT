using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUCliente
{
    public class CUBuscarClientesPorMonto : ICUBuscarClientesPorMonto
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientesPorMonto(IRepositorioCliente repo)
        {
            Repo = repo;
        }

        public List<Cliente> BuscarClientes(double monto)
        {
            return Repo.BuscarPorMonto(monto);
        }
    }
}
