using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Articulo: IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string CodigoProveedor { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }

        public Articulo(string nombre, string descripcion, string codigoProveedor, double precioVenta, int stock)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            CodigoProveedor = codigoProveedor;
            PrecioVenta = precioVenta;
            Stock = stock;
        }

        public Articulo()
        {
            
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                throw new ArticuloValidationException("El nombre del artículo no puede estar vacío.");
            }

            if (Descripcion.Length < 5)
            {
                throw new ArticuloValidationException("La descripción del artículo debe tener al menos 5 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(CodigoProveedor) || CodigoProveedor.Length != 13)
            {
                throw new ArticuloValidationException("El código del proveedor debe tener 13 dígitos.");
            }

            if (PrecioVenta < 0)
            {
                throw new ArticuloValidationException("El precio de venta no puede ser negativo.");
            }

            if (Stock < 0)
            {
                throw new ArticuloValidationException("El stock no puede ser negativo.");
            }
        }
    }
}
