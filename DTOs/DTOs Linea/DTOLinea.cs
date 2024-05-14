using DTOs.DTOs_Articulo;
using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Linea
{
    public class DTOLinea
    {
        [Required] 
        public int ArticuloId { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
    }
}
