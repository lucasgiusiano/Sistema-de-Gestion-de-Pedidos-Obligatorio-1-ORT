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
    public class CUListarPedidosAnulados: ICUListarPedidosAnulados
    {
        private readonly IRepositorioPedido _repoPedidio;
        private readonly MapperPedido _mapper;

        public CUListarPedidosAnulados(IRepositorioPedido repo, MapperPedido mapper)
        {
            _repoPedidio = repo;
            _mapper = mapper;
        }

        public List<DTOPedido> ListarPedidosAnulados()
        {
            var pedidos = _repoPedidio.ListarPedidosAnulados();
            return _mapper.MapPedidosADTO(pedidos);
        }

       
    }
}
