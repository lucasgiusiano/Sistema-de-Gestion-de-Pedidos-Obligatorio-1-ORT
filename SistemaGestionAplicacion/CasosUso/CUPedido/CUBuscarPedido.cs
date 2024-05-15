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
    public class CUBuscarPedido :ICUBuscarPedido
    {
        private readonly IRepositorioPedido _repoPedido;
        private readonly MapperPedido _mapper;



        public CUBuscarPedido(IRepositorioPedido repoPedido, MapperPedido mapper)
        {
            _repoPedido = repoPedido;
            _mapper = mapper;
        }

        public Task<DTOPedido> BuscarPedidoPorId(int idPedido)
        {
            var pedidoEncontrado = _repoPedido.BuscarPorId(idPedido);
            if(pedidoEncontrado != null)
            {
                var dtoPedido = _mapper.ToDTOPedido(pedidoEncontrado);
                return Task.FromResult(dtoPedido);
            }
            return Task.FromResult<DTOPedido>(null);
        }
    }
}
