using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.InterfacesRepositorio
{
    public interface IRepositorioPedido
    {
        void Alta(Pedido nuevo);
        void Anular(int id);
        Pedido BuscarPorId(int id);
        List<Pedido> ListadoFiltrado(DateTime fechaFiltro);
        IEnumerable<Pedido> ObtenerPedidosPorMonto(double monto);
    }
}
