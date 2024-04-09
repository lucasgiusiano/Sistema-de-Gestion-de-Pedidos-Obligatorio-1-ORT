using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public abstract class Pedido 
    {
        public Guid Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public Cliente Cliente { get; set; }
        public List<Linea> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
            Lineas = new List<Linea>();
        }

        public void AnularPedido()
        {
            Anulado = true;
        }

        public abstract double CalcularTotal();

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
