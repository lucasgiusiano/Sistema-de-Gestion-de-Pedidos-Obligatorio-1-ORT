using SistemaGestionNegocio.Dominio;
using System.Collections.Generic;
using DTOs.DTOs_Articulo;
using SistemaGestionNegocio.InterfacesRepositorio;

namespace DTOs.DTOs_Linea
{
    public class MapperLinea
    {
        private readonly IRepositorioArticulo _articuloService;

        public MapperLinea(IRepositorioArticulo articuloService)
        {
            _articuloService = articuloService;
        }

        public DTOLinea ToDTOLinea(Linea linea)
        {
            return new DTOLinea
            {
                ArticuloId = linea.Articulo.Id,
                Cantidad = linea.Cantidad,
                
            };
        }

        public List<DTOLinea> ToListaDTOLinea(List<Linea> lineas)
        {
            var listaDTO = new List<DTOLinea>();
            foreach (var linea in lineas)
            {
                listaDTO.Add(ToDTOLinea(linea));
            }
            return listaDTO;
        }

        public Linea ToLinea(DTOLinea dtoLinea)
        {
            Articulo articulo = _articuloService.BuscarPorId(dtoLinea.ArticuloId);

            return new Linea
            {
                Articulo = articulo,
                Cantidad = dtoLinea.Cantidad,
                PrecioUnitario = articulo.PrecioVenta.Valor,
               
            };
        }
    }
}
