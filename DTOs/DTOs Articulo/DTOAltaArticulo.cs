using SistemaGestionNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Articulo
{
	public class DTOAltaArticulo
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public string CodigoProveedor { get; set; }
		public double PrecioVenta { get; set; }
		public int Stock { get; set; }


		public DTOAltaArticulo(int id, string nombre, string descripcion, string codigoProveedor, double precioVenta, int stock)
		{
			Id = id;
			Nombre = nombre;
			Descripcion = descripcion;
			CodigoProveedor = codigoProveedor;
			PrecioVenta = precioVenta;
			Stock = stock;
		}

		public DTOAltaArticulo( string nombre, string descripcion, string codigoProveedor, double precioVenta, int stock)
		{
			Nombre = nombre;
			Descripcion = descripcion;
			CodigoProveedor = codigoProveedor;
			PrecioVenta = precioVenta;
			Stock = stock;
		}

		public DTOAltaArticulo()
        {
            
        }
    }
}
