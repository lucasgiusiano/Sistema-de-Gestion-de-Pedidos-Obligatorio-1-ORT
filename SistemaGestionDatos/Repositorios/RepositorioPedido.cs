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
        public SistemaGestionContext DBContext { get; set; }

        public RepositorioPedido(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }

        public void Alta(Pedido nuevo)
        {
            if (nuevo != null)
            {
                nuevo.Validar();
                DBContext.Pedidos.Add(nuevo);
                DBContext.SaveChanges();
            }
        }

        public void Anular(Guid id)
        {
            Pedido aAnular = BuscarPorId(id);
            if (aAnular != null)
            {
                aAnular.AnularPedido();
                DBContext.Update(aAnular);
                DBContext.SaveChanges();
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            return DBContext.Pedidos.Where(p => p.Id == id).SingleOrDefault();
        }

        public List<Pedido> ListadoFiltrado(DateTime fechaFiltro)
        {
            //Devuelve hechos en la fecha filtrada que no hayan sido entregadas aún
            //(Usa el valor de la fecha de entrega para saber si ya fue entregado o no si es != de DateTime.MinValue asume que se entregó)
            return DBContext.Pedidos.Where(p => p.FechaPedido.Date == fechaFiltro.Date && p.FechaEntrega == DateTime.MinValue).ToList();
        }
    }
}
