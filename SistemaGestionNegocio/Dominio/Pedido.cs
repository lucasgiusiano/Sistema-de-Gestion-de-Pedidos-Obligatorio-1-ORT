using SistemaGestionNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaGestionNegocio.Dominio
{
    public abstract class Pedido : IValidable
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }

        public abstract double CalcularTotal(double iva);

        public virtual void Validar()
        {
            if (FechaEntrega < FechaPedido.AddDays(7))
            {
                throw new InvalidOperationException("La fecha de entrega prometida no puede ser menor a una semana (7 dìas).");
            }
        }
    }

    public class PedidoExpress : Pedido
    {
        [NotMapped]
        public int PlazoMaximoExpress { get; set; }

        public override double CalcularTotal(double iva)
        {
            double precioTotal = Lineas.Sum(linea => linea.Cantidad * linea.PrecioUnitario);

            double factorMultiplicidad = 1.1;
            // Aplicar recargo por ser express
            // Verificar si la entrega es en el mismo día
            if (FechaEntrega.Date == DateTime.Today)
            {
                factorMultiplicidad = 1.15;
            }

            precioTotal = precioTotal * factorMultiplicidad;
            
            // Aplicar IVA
            precioTotal *= (precioTotal * (iva/ 100));

            return precioTotal;
        }


        public override void Validar()
        {
            base.Validar();

            if ((FechaEntrega - FechaPedido).TotalDays > PlazoMaximoExpress)
            {
                throw new InvalidOperationException($"La fecha de entrega prometida no puede superar los {PlazoMaximoExpress} días para un pedido express.");
            }
        }
    }

    public class PedidoComun : Pedido
    {
        public PedidoComun() : base()
        {

        }

        public override void Validar()
        {
            base.Validar();

            if ((FechaEntrega - FechaPedido).TotalDays < 7)
            {
                throw new InvalidOperationException($"La fecha de entrega prometida no puede ser inferior a una semana para un pedido comun.");
            }
        }

        public override double CalcularTotal(double iva)
        {
            double precioTotal = Lineas.Sum(linea => linea.Cantidad * linea.PrecioUnitario);

            // Aplicar recargo si la distancia a la dirección de entrega supera los 100 km
            if (Cliente.DistanciaDeposito > 100)
            {
                precioTotal *= 1.05; // Recargo del 5%
            }

            // Aplicar IVA
            precioTotal *= (precioTotal * (iva / 100));

            return precioTotal;
        }
    }
}
