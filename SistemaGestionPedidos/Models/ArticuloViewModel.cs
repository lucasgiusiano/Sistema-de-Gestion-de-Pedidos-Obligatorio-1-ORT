using System.CodeDom;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPedidos.Models
{
    public class ArticuloViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del artículo es requerido.")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "El nombre del artículo debe tener entre 10 y 200 caracteres.")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "La descripción del artículo es requerida.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El código del proveedor es requerido.")]
        [StringLength(13, ErrorMessage = "El código del proveedor debe tener exactamente 13 caracteres.")]
        public string CodigoProveedor { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "El precio de venta es requerido.")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor o igual a cero.")]
        public double PrecioVenta { get; set; }

        [Display(Name = "En Stock")]
        [Required(ErrorMessage = "El stock es requerido.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser mayor o igual a cero.")]
        public int Stock { get; set; }

        public ArticuloViewModel(string nombre, string descripcion, string codigoProveedor, double precioVenta, int stock)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CodigoProveedor = codigoProveedor;
            PrecioVenta = precioVenta;
            Stock = stock;
		}

        public ArticuloViewModel()
        {
        }
    }
}
