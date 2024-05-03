using Microsoft.EntityFrameworkCore;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        public SistemaGestionContext DBContext { get; set; }

        public RepositorioPedido(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }

        public void Alta(Pedido pedido)
        {
            ValidarYCrearPedido(pedido);
        }

        private void ValidarYCrearPedido(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido proporcionado es nulo.");
            }

            ValidarCliente(pedido.Cliente);
            ValidarLineasPedido(pedido.Lineas);
            AsignarFechaPedido(pedido);
            VerificarStock(pedido);
            CalcularPrecioFinal(pedido);

            DBContext.Pedidos.Add(pedido);
            DBContext.SaveChanges();
        }

        private void ValidarCliente(Cliente cliente)
        {
            if (cliente == null || !DBContext.Clientes.Any(c => c.Id == cliente.Id))
            {
                throw new Exception("El cliente no existe.");
            }
        }
        private void ValidarLineasPedido(List<Linea> lineasPedido)
        {
            if (lineasPedido == null || lineasPedido.Count == 0)
            {
                throw new Exception("El pedido debe contener al menos una línea de pedido.");
            }

            foreach (var linea in lineasPedido)
            {
                if (linea == null || linea.Articulo == null)
                {
                    throw new Exception("Una línea de pedido o su artículo asociado es nulo.");
                }

                var articulo = DBContext.Articulos.FirstOrDefault(a => a.Id == linea.Articulo.Id);
                if (articulo == null)
                {
                    throw new Exception($"El artículo con ID {linea.Articulo.Id} no existe en la base de datos.");
                }

                if (linea.Cantidad <= 0)
                {
                    throw new Exception("La cantidad de artículo en una línea de pedido debe ser mayor que cero.");
                }
            }
        }

        private void AsignarFechaPedido(Pedido pedido)
        {
            pedido.FechaPedido = DateTime.Now;
        }

        private void VerificarStock(Pedido pedido)
        {
            foreach (var linea in pedido.Lineas)
            {
                if (!DBContext.Articulos.Any(a => a.Id == linea.Articulo.Id && a.Stock.Valor >= linea.Cantidad))
                {
                    throw new Exception("No hay suficiente stock para uno o más artículos del pedido.");
                }
            }
        }

        private void CalcularPrecioFinal(Pedido pedido)
        {
            pedido.PrecioFinal = pedido.CalcularTotal();
        }

        public void AnularPedido(DateTime fechaEmision)
        {
            MostrarPedidosNoEntregados(fechaEmision);
            // Lógica para seleccionar y anular un pedido
        }

        public List<Pedido> ObtenerPedidosAnulados()
        {
            return DBContext.Pedidos
                .Where(p => p.Anulado)
                .OrderByDescending(p => p.FechaPedido)
                .ToList();
        }

       

        public void Anular(int id)
        {
            Pedido pedido = BuscarPorId(id);
            if (pedido != null)
            {
                pedido.Anulado = true;
                DBContext.Update(pedido);
                DBContext.SaveChanges();
            }
        }

        public Pedido BuscarPorId(int id)
        {
            return DBContext.Pedidos.SingleOrDefault(p => p.Id == id);
        }

        public List<Pedido> ListadoFiltrado(DateTime fechaFiltro)
        {
            return DBContext.Pedidos
                .Where(p => p.FechaPedido.Date == fechaFiltro.Date && p.FechaEntrega == DateTime.MinValue)
                .ToList();
        }

        public IEnumerable<Pedido> ObtenerPedidosPorMonto(double monto)
        {
            return DBContext.Pedidos.Where(p => p.CalcularTotal() > monto);
        }

      

        private void MostrarPedidosNoEntregados(DateTime fechaEmision)
        {
            List<Pedido> pedidosNoEntregados = DBContext.Pedidos
                .Where(p => p.FechaPedido.Date == fechaEmision.Date && !p.Anulado)
                .ToList();

            foreach (var pedido in pedidosNoEntregados)
            {
                Console.WriteLine($"Fecha Prometida de Entrega: {pedido.FechaEntrega}, Cliente: {pedido.Cliente.RazonSocial}, Total del Pedido: {pedido.PrecioFinal}");
            }
        }
    }
}
