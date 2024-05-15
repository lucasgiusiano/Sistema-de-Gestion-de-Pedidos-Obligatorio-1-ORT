namespace SistemaGestionPedidos.Models
{
    public class LineaViewModel
    {
        public int Id { get; set; }
        public ArticuloViewModel Articulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }

        public LineaViewModel(int id, ArticuloViewModel articulo, int cantidad, double precioUnitario, double subtotal)
        {
            Id = id;
            Articulo = articulo;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            Subtotal = subtotal;
        }

        public LineaViewModel()
        {

        }
    }
}
