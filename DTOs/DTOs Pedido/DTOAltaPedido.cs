using DTOs.DTOs_Configuracion;
using DTOs.DTOs_Linea;
using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Pedido
{
    public class DTOAltaPedido
    {
        [Required(ErrorMessage = "La Fecha de entrega es requerida.")]
        public DateTime FechaEntrega { get; set; }
       
        [Required(ErrorMessage = "El id de cliente es es requerido.")]
        public int ClienteId { get; set; }

        // representa la lista de articulos, a partir del articuloID de cada linea, puedo determinar el articulo
        [Required(ErrorMessage = "La lista de líneas es requerida.")]
        [MinLength(1, ErrorMessage = "La lista de líneas debe contener al menos un elemento.")]
        public List<DTOLinea> Lineas { get; set; }
        public string TipoPedido { get; set; }


    }

}
