using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUPedido
{
    public class CUAltaPedido : ICUAlta<Pedido>
    {
        public IRepositorioPedido Repo { get; set; }

        public CUAltaPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public void Alta(Pedido nuevo)
        {
            Repo.Alta(nuevo);
        }
    }
}
