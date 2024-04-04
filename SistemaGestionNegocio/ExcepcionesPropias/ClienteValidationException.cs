using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class ClienteValidationException: Exception
    {
        public ClienteValidationException()
        {
        }

        public ClienteValidationException(string message): base(message)
        {
        }

        public ClienteValidationException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}
