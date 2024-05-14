using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Linea
    {
        public int Id { get; set; }
        
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public int ArticuloId { get; set; }
        public virtual Articulo Articulo { get; set; }

        public Linea(Articulo articulo, int cantidad, double precioUnitario)
        {
            Articulo = articulo;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }

        public Linea()
        {
        }

        public double CalcularSubtotal()
        {
            return Cantidad * PrecioUnitario;
        }
    }
}
