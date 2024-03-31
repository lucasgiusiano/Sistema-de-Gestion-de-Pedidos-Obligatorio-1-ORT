using SistemaGestionNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class PedidoComun : Pedido
    {
        public override double CalcularTotal()
        {
            double total = 0;
            foreach (var linea in Lineas)
            {
                total += linea.CalcularSubtotal();
            }
            // Aplica recargo si la distancia a la dirección de entrega supera los 100 km
            if (Cliente.Direccion.DistanciaDeposito > 100)
            {
                total *= 1.05;
            }

            // Calcula el IVA del total 
            total *= 1.22;

            return total;
        }

        
    }
}
