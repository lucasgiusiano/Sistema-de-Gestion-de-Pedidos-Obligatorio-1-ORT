using SistemaGestionNegocio.Dominio;

namespace SistemaGestionPedidos.Models
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public List<LineaViewModel> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }
        public int PlazoMaximoExpress { get; set; }

        public PedidoViewModel(int id, DateTime fechaPedido, DateTime fechaEntrega, ClienteViewModel cliente, List<LineaViewModel> lineas, bool anulado, double precioFinal, int plazoMaximoExpress)
        {
            Id = id;
            FechaPedido = fechaPedido;
            FechaEntrega = fechaEntrega;
            Cliente = cliente;
            Lineas = lineas;
            Anulado = anulado;
            PrecioFinal = precioFinal;
            PlazoMaximoExpress = plazoMaximoExpress;
        }

        public PedidoViewModel()
        {
            
        }
    }
}
