using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUPedido
{
    public class CUListadoPedidosAnuladosXFecha : ICUListadoPedidosAnuladosXFecha
    {
        public IRepositorioPedido Repo { get; set; }

        public CUListadoPedidosAnuladosXFecha(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public List<Pedido> ListadoFiltrado(DateTime fechaFiltro)
        {
            return Repo.ListadoFiltrado(fechaFiltro);
        }
    }
}
