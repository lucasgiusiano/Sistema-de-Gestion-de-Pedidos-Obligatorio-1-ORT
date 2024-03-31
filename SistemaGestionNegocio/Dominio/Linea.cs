using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Linea
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public Linea(Articulo articulo, int cantidad, double precioUnitario)
        {
            Articulo = articulo;
            Cantidad = cantidad;
            PrecioUnitario = CalcularSubtotal();
        }

        public double CalcularSubtotal()
        {
            return Cantidad * Articulo.PrecioVenta;
        }
    }
}
