using DTOs.DTOs_Linea;
using DTOs.DTOs_Pedido;
using Microsoft.EntityFrameworkCore;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUPedido
{
    public class CUAltaPedido : ICUAltaPedido
    {
        private readonly IRepositorioPedido _repoPedido;
        private readonly IRepositorioArticulo _repoArticulo;
        private readonly IRepositorioCliente _repoCliente;
        private readonly IRepositorioConfiguracion _repositorioConfiguracion;
        private readonly MapperPedido _mapper;



        public CUAltaPedido(IRepositorioPedido repoPedido, IRepositorioArticulo repoArticulo, IRepositorioCliente repoCliente, IRepositorioConfiguracion repoConfig, MapperPedido mapper)
        {
            _repoPedido = repoPedido;
            _repoArticulo = repoArticulo;
            _repoCliente = repoCliente;
            _repositorioConfiguracion = repoConfig;
            _mapper = mapper;
        }

        public async Task<DTOPedido> Alta(DTOAltaPedido nuevoPedido)
        {
            var cliente = ValidarYObtenerCliente(nuevoPedido.ClienteId);
            var plazoMaximoExpress = _repositorioConfiguracion.ObtenerPlazoMaximoExpress();

            ValidarPedido(nuevoPedido, plazoMaximoExpress);

            Pedido pedido = CrearObjetoPedido(nuevoPedido, cliente, plazoMaximoExpress);

            AsignarFechaPedido(pedido);

            CalcularPrecioFinal(pedido);

            var pedidoAgregado = _repoPedido.Alta(pedido);

            return _mapper.ToDTOPedidoConInfoBasica(pedidoAgregado);
        }

        private Cliente ValidarYObtenerCliente(int clienteId)
        {
            var cliente = _repoCliente.BuscarClientePorId(clienteId);
            if (cliente == null)
            {
                throw new Exception($"El cliente con ID {clienteId} no existe.");
            }
            return cliente;
        }
        private void ValidarPedido(DTOAltaPedido pedidoDTO, double plazoMaximoExpress)
        {

            // Verificar stock suficiente
            foreach (var linea in pedidoDTO.Lineas)
            {
                var articulo = _repoArticulo.BuscarPorId(linea.ArticuloId);
                if (articulo == null)
                {
                    throw new Exception($"El artículo con ID {linea.ArticuloId} no existe en la base de datos.");
                }

                if (linea.Cantidad > articulo.Stock.Valor)
                {
                    throw new Exception($"No hay stock suficiente del artículo {articulo.Nombre.Valor}.");
                }

                // corroboro si es coherente que haya elegido pedido express con el plazo de entrega acorde al tipo de pedido
                if (pedidoDTO.TipoPedido.Equals("express", StringComparison.OrdinalIgnoreCase))
                {
                    if ((pedidoDTO.FechaEntrega - DateTime.Now).TotalDays > plazoMaximoExpress)
                    {
                        throw new Exception($"El plazo de entrega para un pedido express no puede ser mayor a {plazoMaximoExpress} días.");
                    }
                }

                // corroboro que si eligio pedido coomun, el plazo de entrega no sea menor a una semana como lo pide la letra
                if (pedidoDTO.TipoPedido.Equals("comun", StringComparison.OrdinalIgnoreCase))
                {
                    if ((pedidoDTO.FechaEntrega - DateTime.Now).TotalDays < 7)
                    {
                        throw new Exception("El plazo de entrega para un pedido comun no puede ser menor a 7 días.");
                    }
                }

            }
        }

        private Pedido CrearObjetoPedido(DTOAltaPedido pedidoDTO, Cliente cliente, double plazoMaximoEntrega)
        {
            Pedido pedido;

            if (pedidoDTO.FechaEntrega <= DateTime.Today.AddDays(plazoMaximoEntrega))
            {
                // Es pedido express
                pedido = new PedidoExpress();
                ((PedidoExpress)pedido).PlazoMaximoExpress = Convert.ToInt32(plazoMaximoEntrega);
            }
            else
            {
                // Es pedido común
                pedido = new PedidoComun();
            }

            pedido.FechaEntrega = pedidoDTO.FechaEntrega;
            pedido.Cliente = cliente;
            pedido.Lineas = pedidoDTO.Lineas.Select(linea =>
            {
                var articulo = _repoArticulo.BuscarPorId(linea.ArticuloId);

                return new Linea
                {
                    ArticuloId = linea.ArticuloId,
                    Cantidad = linea.Cantidad,
                    PrecioUnitario = articulo.PrecioVenta.Valor,
                    Articulo = articulo,
                };
            }).ToList();

            return pedido;
        }

        private void AsignarFechaPedido(Pedido pedido)
        {
            pedido.FechaPedido = DateTime.Now;
        }

        private void CalcularPrecioFinal(Pedido pedido)
        {

            double iva = _repositorioConfiguracion.ObtenerIVA();
            double recargoPedidoExpressDia = _repositorioConfiguracion.ObtenerRecargoPedidoExpressEnElDia();
            double recargoPedidoExpress = _repositorioConfiguracion.ObtenerRecargoPedidoExpress();
            double recargoPedidoComun = _repositorioConfiguracion.ObtenerRecargoPedidoComun();


            pedido.PrecioFinal = pedido.CalcularTotal(iva,recargoPedidoExpressDia,recargoPedidoExpress, recargoPedidoComun);
        }



    }
}
