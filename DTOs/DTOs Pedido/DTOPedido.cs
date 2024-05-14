using DTOs.DTOs_Cliente;
using DTOs.DTOs_Linea;
using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Pedido
{
    public class DTOPedido
    {
        public int Id { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public DTOCliente Cliente { get; set; }
        public List<DTOLinea> Lineas { get; set; }
        public bool Anulado { get; set; }
        public double PrecioFinal { get; set; }
    }
}
