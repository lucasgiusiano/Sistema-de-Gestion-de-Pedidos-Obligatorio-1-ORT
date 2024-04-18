using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUPedido
{
    public class CUAnularPedido : ICUAnularPedido
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAnularPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public void Anular(int id)
        {
            Repo.Anular(id);
        }
    }
}
