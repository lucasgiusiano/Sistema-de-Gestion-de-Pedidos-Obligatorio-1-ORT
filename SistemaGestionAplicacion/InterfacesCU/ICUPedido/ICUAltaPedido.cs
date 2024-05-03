using DTOs.DTOs_Pedido;
using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUPedido
{
    public interface ICUAltaPedido
    {
        public Task Alta(DTOAltaPedido nuevo);
    }
}
