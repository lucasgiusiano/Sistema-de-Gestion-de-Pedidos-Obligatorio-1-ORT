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


        public Articulo()
        {
            
        }

        public void Validar()
        {
            // a este metodo no llegaria si ya no es valido, porque romperia a nivel de validacion en el view model por las anotaciones
        }
    }
}
