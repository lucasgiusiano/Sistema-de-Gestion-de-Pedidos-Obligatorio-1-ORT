using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public abstract class Pedido 
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }

        protected Pedido(DateTime fechaPedido, DateTime fechaEntrega, Cliente cliente, List<Linea> lineas, bool anulado, double precioFinal)
        {
            FechaPedido = fechaPedido;
            FechaEntrega = fechaEntrega;
            Cliente = cliente;
            Lineas = lineas;
            Anulado = false;
            PrecioFinal = precioFinal;
        }

        public Pedido()
        {
            Anulado = false;
            Lineas = new List<Linea>();
        }

        public void AnularPedido()
        {
            Anulado = true;
        }

        public abstract double CalcularTotal();

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
