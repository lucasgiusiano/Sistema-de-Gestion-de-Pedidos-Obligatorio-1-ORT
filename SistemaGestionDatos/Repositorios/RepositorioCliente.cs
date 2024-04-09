using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        public SistemaGestionContext DBContext { get; set; }

        public RepositorioCliente(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }

        public List<Cliente> BuscarPorMonto(double monto)
        {
            //Selecciona de la tabla pedidos los que superan el monto solicitado y a partir de ella topa solo el atributo que contiene el cliente
            //Por ultimo se asegura de que no haya clientes repetidos con .Distinct()
            return DBContext.Pedidos.Where(p => p.PrecioFinal > monto).Select(p => p.Cliente).Distinct().ToList();
        }

        public Cliente BuscarPorRazonSocial(string razonSocial)
        {
            return DBContext.Clientes.Where(c => c.RazonSocial == razonSocial).SingleOrDefault();
        }
    }
}
