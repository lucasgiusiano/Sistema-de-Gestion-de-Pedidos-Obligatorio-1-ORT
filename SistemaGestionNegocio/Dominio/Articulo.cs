using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionNegocio.InterfacesDominio;
using SistemaGestionNegocio.VOs;
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
        public NombreArticulo Nombre { get; set; }
        public DescripcionArticulo Descripcion { get; set; }
        public CodigoProveedorArticulo CodigoProveedor { get; set; }
        public PrecioVentaArticulo PrecioVenta { get; set; }
        public StockArticulo Stock { get; set; }

        public Articulo(NombreArticulo nombre, DescripcionArticulo descripcion, CodigoProveedorArticulo codigoProveedor, PrecioVentaArticulo precioVenta, StockArticulo stock)
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
        }
    }
}
