using SistemaGestionNegocio.InterfacesDominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;

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
        public Configuracion Configuracion { get; set; }

        protected Pedido(List<Linea> lineas)
        {
            Lineas = lineas;
        }

        public Pedido()
        {

        }

        // Repositorio de configuraciones
        private readonly IRepositorioConfiguracion _repositorioConfiguracion;

        protected Pedido(IRepositorioConfiguracion repositorioConfiguracion)
        {
            _repositorioConfiguracion = repositorioConfiguracion;
        }

        public abstract double CalcularTotal();

        public virtual void Validar()
        {
            // Validaciones comunes a todos los tipos de pedido
            if (FechaEntrega < FechaPedido.AddDays(7))
            {
                throw new InvalidOperationException("La fecha de entrega prometida no puede ser menor a una semana (7 dìas).");
            }
        }
    }

    public class PedidoExpress : Pedido
    {
        public double PlazoMaximoExpress { get; }
        private readonly double _iva;

        public PedidoExpress(List<Linea> lineas, IRepositorioConfiguracion repositorioConfiguracion)
            : base(lineas)
        {
            PlazoMaximoExpress = repositorioConfiguracion.ObtenerPlazoMaximoExpress();
            _iva = repositorioConfiguracion.ObtenerIVA();
        }

        public PedidoExpress() : base()
        {

        }

        public override double CalcularTotal()
        {
            double precioTotal = Lineas.Sum(linea => linea.Cantidad * linea.PrecioUnitario);

            // Aplicar recargo por ser express
            precioTotal *= 1.1; // Recargo del 10%
            if (FechaEntrega.Date == DateTime.Now)
            {
                precioTotal *= 1.15; // Recargo adicional del 15% si la entrega es el mismo día
            }

            // Aplicar IVA
            precioTotal *= (1 + _iva / 100);

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
        private readonly double _iva;

        public PedidoComun(List<Linea> lineas, IRepositorioConfiguracion repositorioConfiguracion) : base(lineas)
        {
            _iva = repositorioConfiguracion.ObtenerIVA();
        }

        public PedidoComun() : base()
        {

        }

        public override double CalcularTotal()
        {
            double precioTotal = Lineas.Sum(linea => linea.Cantidad * linea.PrecioUnitario);

            // Aplicar recargo si la distancia a la dirección de entrega supera los 100 km
            if (Cliente.DistanciaDeposito > 100)
            {
                precioTotal *= 1.05; // Recargo del 5%
            }

            // Aplicar IVA
            precioTotal *= (1 + _iva / 100);

            return precioTotal;
        }
    }
}
