using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class PedidoExpress : Pedido
    {

        public int PlazoMaximo { get; set; }


        public PedidoExpress(DateTime fechaPedido, DateTime fechaEntrega, Cliente cliente, List<Linea> lineas, bool anulado, double precioFinal, int plazoMaximo) : base(fechaPedido, fechaEntrega, cliente, lineas, anulado, precioFinal)
        {
            plazoMaximo = PlazoMaximo;
        }

        public PedidoExpress()
        {
        }

        public override double CalcularTotal()
        {
            double total = 0;
            foreach (var linea in Lineas)
            {
                total += linea.CalcularSubtotal();
            }

            // Calcular la diferencia en dias entre la fecha de pedido y la fecha de entrega
            int diasDeEntrega = (FechaEntrega - FechaPedido).Days;

            // Verifica si el plazo máximo de entrega se supera y aplicar recargo
            if (diasDeEntrega > PlazoMaximo)
            {
                total *= 1.10;
            }

            // Verifica si la fecha de entrega es en el mismo día y aplicar recargo adicional
            if (diasDeEntrega == 0)
            {
                total *= 1.15;
            }

            total *= 1.22;

            return total;
        }
    }
}
