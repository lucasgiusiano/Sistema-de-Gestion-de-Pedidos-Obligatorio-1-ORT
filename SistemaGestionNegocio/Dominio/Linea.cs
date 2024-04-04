using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Linea
    {
        public Guid Id { get; set; }
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public Linea()
        {
            Id = Guid.NewGuid();
        }

        public double CalcularSubtotal()
        {
            return Cantidad * PrecioUnitario;
        }
    }
}
