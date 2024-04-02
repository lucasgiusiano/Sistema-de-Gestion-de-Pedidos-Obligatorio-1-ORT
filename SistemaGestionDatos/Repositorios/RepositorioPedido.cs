using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioPedido : IRepositorioPedido
    {
        public void Alta(Pedido nuevo)
        {
            throw new NotImplementedException();
        }

        public void Anular(int id)
        {
            throw new NotImplementedException();
        }

        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListadoFiltrado(DateTime fechaFiltro1, DateTime fechaFiltro2)
        {
            throw new NotImplementedException();
        }
    }
}
