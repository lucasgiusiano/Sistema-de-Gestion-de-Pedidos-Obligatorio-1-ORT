using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUCliente
{
    public class CUBuscarClientesPorNombre : ICUBuscarClientesPorNombre
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientesPorNombre(IRepositorioCliente repo)
        {
            Repo = repo;
        }


        public List<Cliente> BuscarClientesPorNOA(string nombreOApellido)
        {
            return Repo.BuscarPorNombreApellido(nombreOApellido);
        }
    }
}
