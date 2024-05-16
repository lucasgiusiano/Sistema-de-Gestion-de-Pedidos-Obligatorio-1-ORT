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
    public class Articulo
    {
        public int Id { get; set; }
        public NombreArticulo Nombre { get; set; }
        public DescripcionArticulo Descripcion { get; set; }
        public CodigoProveedorArticulo CodigoProveedor { get; set; }
        public PrecioVentaArticulo PrecioVenta { get; set; }
        public StockArticulo Stock { get; private set; }

        public Articulo(int id,NombreArticulo nombre, DescripcionArticulo descripcion, CodigoProveedorArticulo codigoProveedor, PrecioVentaArticulo precioVenta, StockArticulo stock)
		{
            Id = id;
			Nombre = nombre;
			Descripcion = descripcion;
			CodigoProveedor = codigoProveedor;
			PrecioVenta = precioVenta;
			Stock = stock;
		}
        
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

		public bool VerificarStockSuficiente(int cantidad)
        {
            return Stock.Valor >= cantidad;
        }

        public void ReducirStock(int cantidad)
        {
            if (VerificarStockSuficiente(cantidad))
            {
                // Crear un nuevo objeto StockArticulo con el stock reducido
                Stock = new StockArticulo(Stock.Valor - cantidad);
            }
            else
            {
                throw new StockInsuficienteException($"No hay suficiente stock disponible para el artículo {Nombre}");
            }
        }

    }
}
