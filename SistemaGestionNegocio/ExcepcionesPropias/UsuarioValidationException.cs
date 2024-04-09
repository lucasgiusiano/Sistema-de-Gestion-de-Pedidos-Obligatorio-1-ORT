using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class UsuarioValidationException: Exception
    {
        public UsuarioValidationException()
        {
        }

        public UsuarioValidationException(string message)
            : base(message)
        {
        }

        public UsuarioValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
