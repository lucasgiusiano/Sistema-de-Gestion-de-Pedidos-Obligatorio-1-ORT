using DTOs.DTOs_Configuracion;
using DTOs.DTOs_Linea;
using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Pedido
{
    public class DTOAltaPedido
    {
        public DateTime FechaEntrega { get; set; }
        public int ClienteId { get; set; }

        // representa la lista de articulos, a partir del articuloID de cada linea, puedo determinar el articulo
        public List<DTOLinea> Lineas { get; set; }
        

    }

}
