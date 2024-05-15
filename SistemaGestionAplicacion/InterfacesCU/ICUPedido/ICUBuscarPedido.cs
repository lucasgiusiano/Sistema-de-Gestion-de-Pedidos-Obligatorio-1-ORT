using DTOs.DTOs_Pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUPedido
{
    public interface ICUBuscarPedido
    {
        public Task<DTOPedido> BuscarPedidoPorId(int idPedido);

    }
}
