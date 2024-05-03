using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;

namespace SistemaGestionNegocio.InterfacesRepositorio
{
    public interface IRepositorioPedido
    {
        void Alta(Pedido pedido);
        void AnularPedido(DateTime fechaEmision);
        List<Pedido> ObtenerPedidosAnulados();
        void Anular(int id);
        Pedido BuscarPorId(int id);
        List<Pedido> ListadoFiltrado(DateTime fechaFiltro);
        IEnumerable<Pedido> ObtenerPedidosPorMonto(double monto);
    }
}
