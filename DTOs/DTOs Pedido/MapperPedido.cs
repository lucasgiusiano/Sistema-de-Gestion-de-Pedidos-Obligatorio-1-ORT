using SistemaGestionNegocio.Dominio;
using DTOs.DTOs_Pedido;
using System;
using System.Collections.Generic;
using SistemaGestionNegocio.InterfacesRepositorio;
using DTOs.DTOs_Linea;

namespace DTOs.DTOs_Pedido
{
    public class MapperPedido
    {
        private readonly IRepositorioConfiguracion _repositorioConfiguracion;
        private readonly MapperLinea mapperLinea;
        private readonly IRepositorioCliente _repositorioCliente;


        public MapperPedido(IRepositorioConfiguracion repositorioConfiguracion, MapperLinea mapperLinea, IRepositorioCliente cliente)
        {
            _repositorioConfiguracion = repositorioConfiguracion;
            this.mapperLinea = mapperLinea;
            _repositorioCliente = cliente;
        }

        public Pedido MapToPedido(DTOAltaPedido dto)
        {
            DateTime fechaEntrega = dto.FechaEntrega;
            Cliente cliente = _repositorioCliente.BuscarClientePorId(dto.ClienteId);
            List<DTOLinea> lineas = dto.Lineas; 
            List<Linea> lineasEntity = new List<Linea>();
            

            foreach (var dtolinea in dto.Lineas)
            {
                // aca tenes que usar el maper de linea, para agregar la lista de lineas a partir de cada una de las lineaDTO
                lineasEntity.Add(mapperLinea.ToLinea(dtolinea));
                
            }
            // Determinar si es PedidoExpress o PedidoComun según la fecha de entrega
            Pedido pedido;
            if ((fechaEntrega - DateTime.Now).TotalDays <= _repositorioConfiguracion.ObtenerPlazoMaximoExpress())
            {
                // Si la fecha de entrega es menor o igual al plazo máximo de PedidoExpress, es un PedidoExpress
                pedido = new PedidoExpress(lineasEntity, _repositorioConfiguracion);
            }
            else
            {
                // Si la fecha de entrega es mayor al plazo máximo de PedidoExpress, es un PedidoComun
                pedido = new PedidoComun(lineasEntity, _repositorioConfiguracion);
            }

            pedido.PrecioFinal = pedido.CalcularTotal(); 

            return pedido;
        }

        public DTOAltaPedido ToDTOAltaPedido(Pedido pedido)
        {
            return new DTOAltaPedido
            {
                FechaEntrega = pedido.FechaEntrega,
                ClienteId = pedido.Cliente.Id,
                
            };
        }

        public List<DTOAltaPedido> ToListaDTOAltaPedido(List<Pedido> pedidos)
        {
            return pedidos.ConvertAll(pedido => ToDTOAltaPedido(pedido));
        }
    }
}
