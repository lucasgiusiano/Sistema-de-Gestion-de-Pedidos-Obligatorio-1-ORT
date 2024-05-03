using DTOs.DTOs_Usuario;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Articulo
{
	public class MapperArticulo
	{
		public static Articulo DTOArticuloToArticulo(DTOAltaArticulo dto)
		{
			if (dto.Id != 0)
			{
				return new Articulo(dto.Id, new NombreArticulo(dto.Nombre), new DescripcionArticulo(dto.Descripcion), new CodigoProveedorArticulo(dto.CodigoProveedor), new PrecioVentaArticulo(dto.PrecioVenta), new StockArticulo(dto.Stock));
			}
			else
			{
				return new Articulo(new NombreArticulo(dto.Nombre), new DescripcionArticulo(dto.Descripcion), new CodigoProveedorArticulo(dto.CodigoProveedor), new PrecioVentaArticulo(dto.PrecioVenta), new StockArticulo(dto.Stock));
			}

		}

		public static DTOAltaArticulo toDTOAltaArticulo(Articulo articulo)
		{
			return new DTOAltaArticulo(articulo.Id,articulo.Nombre.Valor, articulo.Descripcion.Valor, articulo.CodigoProveedor.Valor, articulo.PrecioVenta.Valor, articulo.Stock.Valor);
		}

		public static List<DTOAltaArticulo> toListaDTOAltaArticulo(List<Articulo> articulos)
		{
			return articulos.Select(articulo => toDTOAltaArticulo(articulo)).ToList();
		}
	}
}
