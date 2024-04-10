using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;

namespace SistemaGestionPedidos.Models
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public List<LineaViewModel> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }

        // Propiedades específicas de PedidoComun
        public bool EsPedidoComun { get; set; }

        // Propiedades específicas de PedidoExpress
        public bool EsPedidoExpress { get; set; }
        public int PlazoMaximo { get; set; }

        // Constructor
        public PedidoViewModel()
        {
            Cliente = new ClienteViewModel();
            Lineas = new List<LineaViewModel>();
        }
    }
}
