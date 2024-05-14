using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class PedidoNotFoundException: Exception
    {
        public PedidoNotFoundException()
        {
        }

        public PedidoNotFoundException(string message)
            : base(message)
        {
        }

        public PedidoNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
