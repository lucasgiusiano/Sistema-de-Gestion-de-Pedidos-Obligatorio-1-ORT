using DTOs.DTOs_Pedido;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUPedido
{
    public class CUListarPedidosNoEntregadosPorFecha: ICUListarPedidosNoEntregadosPorFecha
    {
        private readonly IRepositorioPedido _repoPedidio;
        private readonly MapperPedido _mapper;

        public CUListarPedidosNoEntregadosPorFecha(IRepositorioPedido repo, MapperPedido mapper)
        {
            _repoPedidio = repo;
            _mapper = mapper;
        }

        public List<DTOPedido> ListarPedidosNoEntregadosPorFecha(DateTime fecha)
        {
            var pedidos = _repoPedidio.ListarPedidosNoEntregadosPorFecha(fecha);
            return _mapper.MapPedidosADTO(pedidos);
        }
    }
}
