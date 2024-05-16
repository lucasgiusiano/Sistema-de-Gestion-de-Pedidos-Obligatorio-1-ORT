using SistemaGestionNegocio.Dominio;
using DTOs.DTOs_Pedido;
using System;
using System.Collections.Generic;
using SistemaGestionNegocio.InterfacesRepositorio;
using DTOs.DTOs_Linea;
using DTOs.DTOs_Cliente;

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
                pedido = new PedidoExpress();
            }
            else
            {
                // Si la fecha de entrega es mayor al plazo máximo de PedidoExpress, es un PedidoComun
                pedido = new PedidoComun();
            }

            pedido.PrecioFinal = pedido.CalcularTotal(_repositorioConfiguracion.ObtenerIVA(), _repositorioConfiguracion.ObtenerRecargoPedidoExpressEnElDia(), _repositorioConfiguracion.ObtenerRecargoPedidoExpress(), _repositorioConfiguracion.ObtenerRecargoPedidoComun()); 

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

        public List<DTOPedido> MapPedidosADTO(List<Pedido> pedidos)
        {
            // Crea una lista para almacenar los DTOs resultantes
            List<DTOPedido> listaDTOs = new List<DTOPedido>();

            // Itera sobre cada Pedido y mapea a DTOPedido
            foreach (var pedido in pedidos)
            {
                // Mapea el pedido a un DTOPedido y agrega a la lista
                listaDTOs.Add(ToDTOPedido(pedido));
            }

            // Devuelve la lista de DTOs resultante
            return listaDTOs;
        }

        public DTOPedido ToDTOPedido(Pedido pedido)
        {
            return new DTOPedido
            {
                Id = pedido.Id,
                FechaPedido = pedido.FechaPedido,
                FechaEntrega = pedido.FechaEntrega,
                Cliente = new DTOCliente
                {
                    Id = pedido.Cliente.Id,
                    RazonSocial = pedido.Cliente.RazonSocial,
                    Rut = pedido.Cliente.Rut,
                    Calle = pedido.Cliente.Direccion.Calle,
                    Numero = pedido.Cliente.Direccion.Numero,
                    Ciudad = pedido.Cliente.Direccion.Ciudad,
                    DistanciaDeposito = pedido.Cliente.DistanciaDeposito
                },
                Lineas = pedido.Lineas.Select(linea => new DTOLinea
                {
                    ArticuloId = linea.ArticuloId,
                    Cantidad = linea.Cantidad
                }).ToList(),
                Anulado = pedido.Anulado,
                PrecioFinal = pedido.PrecioFinal
            };
        }
        public DTOPedido ToDTOPedidoConInfoBasica(Pedido pedido)
        {
            return new DTOPedido
            {
                Id = pedido.Id,
                FechaPedido = pedido.FechaPedido,
                FechaEntrega = pedido.FechaEntrega,
                Anulado = pedido.Anulado,
                PrecioFinal = pedido.PrecioFinal
            };
        }

    }
}
