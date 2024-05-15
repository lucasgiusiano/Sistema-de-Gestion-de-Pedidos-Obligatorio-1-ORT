using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class PedidoValidationException:Exception
    {
        public PedidoValidationException()
        {
        }

        public PedidoValidationException(string message)
            : base(message)
        {
        }

        public PedidoValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
