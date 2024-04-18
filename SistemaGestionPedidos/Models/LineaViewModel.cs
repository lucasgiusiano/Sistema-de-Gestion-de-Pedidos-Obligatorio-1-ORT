namespace SistemaGestionPedidos.Models
{
    public class LineaViewModel
    {
        public int Id { get; set; }
        public ArticuloViewModel Articulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
    }
}
