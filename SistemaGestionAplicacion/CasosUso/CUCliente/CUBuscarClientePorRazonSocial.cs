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
    public class CUBuscarClientePorRazonSocial : ICUBuscarClientePorRazonSocial
    {
        public IRepositorioCliente Repo { get; set; }

        public CUBuscarClientePorRazonSocial(IRepositorioCliente repo)
        {
            Repo = repo;
        }


        public Cliente BuscarClientePorRazonSocial(string razonSocial)
        {
            return Repo.BuscarPorRazonSocial(razonSocial);
        }
    }
}
