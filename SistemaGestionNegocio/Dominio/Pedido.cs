using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public abstract class Pedido
    {
        public Guid Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }

        public Pedido(DateTime fechaPedido, DateTime fechaEntrega, Cliente cliente, List<Linea> lineas, bool anulado, double precioFinal)
        {
            Id = Guid.NewGuid();
            FechaPedido = fechaPedido;
            FechaEntrega = fechaEntrega;
            Cliente = cliente;
            Lineas = lineas;
            Anulado = false;
            PrecioFinal = CalcularTotal();
        }

        public Pedido()
        {
            Id = Guid.NewGuid();
            Anulado = false;
        }

        public abstract double CalcularTotal();
    }
}
