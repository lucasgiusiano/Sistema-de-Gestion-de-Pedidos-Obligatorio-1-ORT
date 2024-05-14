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
        List<Pedido> ListarPedidosAnulados();
        List<Pedido> ListarPedidosNoEntregadosPorFecha(DateTime fecha);
        IEnumerable<Pedido> ObtenerPedidosPorMonto(double monto);
    }
}
