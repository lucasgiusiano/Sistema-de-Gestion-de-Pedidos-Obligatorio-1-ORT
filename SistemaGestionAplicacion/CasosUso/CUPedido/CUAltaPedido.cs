using DTOs.DTOs_Pedido;
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
        public IRepositorioPedido Repo { get; set; }

        public CUAltaPedido(IRepositorioPedido repo)
        {
            Repo = repo;
        }

        public async Task Alta(DTOAltaPedido nuevo)
        {

           
        }
    }
}
