using Microsoft.EntityFrameworkCore;
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
            
            return DBContext.Pedidos.Where(p => p.PrecioFinal > monto).Select(p => p.Cliente).Distinct().ToList();
        }

        public Cliente BuscarPorRazonSocial(string razonSocial)
        {
            return DBContext.Clientes.Where(c => c.RazonSocial == razonSocial).SingleOrDefault();
        }
        public List<Cliente> ObtenerTodosLosClientes()
        {
            return DBContext.Clientes.ToList();
        }
        public List<Cliente> ObtenerTodosLosClientesConDireccion()
        {
            return DBContext.Clientes
                            .Include(c => c.Direccion)
                            .ToList();
        }

    }
}
