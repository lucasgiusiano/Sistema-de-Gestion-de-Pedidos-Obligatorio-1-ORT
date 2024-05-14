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
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "El pedido proporcionado es nulo.");
            }
            pedido.Validar();
            DBContext.Pedidos.Add(pedido);
            DBContext.SaveChanges();
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
            return DBContext.Pedidos.AsNoTracking()
                                    .FirstOrDefault(p => p.Id == id);
        }

        public List<Pedido> ListarPedidosAnulados()
        {
            return DBContext.Pedidos
                .AsNoTracking()
                .Include(p => p.Lineas)
                .Include(p => p.Cliente)
                .ThenInclude(c => c.Direccion)
                .Where(p => p.Anulado == true)
                .OrderByDescending(p => p.FechaPedido)
                .ToList();
        }

        public List<Pedido> ListarPedidosNoEntregadosPorFecha(DateTime fecha)
        {
            return DBContext.Pedidos
               .AsNoTracking()
               .Include(p => p.Lineas)
               .Include(p => p.Cliente)
               .ThenInclude(c => c.Direccion)
               .Where(p => p.FechaPedido.Date == fecha.Date && p.FechaEntrega > DateTime.Now)
               .ToList();
        }


        public IEnumerable<Pedido> ObtenerPedidosPorMonto(double monto)
        {
            return null;
            //return DBContext.Pedidos.Where(p => p.CalcularTotal() > monto);
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
