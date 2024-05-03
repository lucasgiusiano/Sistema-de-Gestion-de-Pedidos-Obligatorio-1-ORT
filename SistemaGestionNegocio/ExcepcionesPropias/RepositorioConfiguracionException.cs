using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class RepositorioConfiguracionException: Exception
    {
        public RepositorioConfiguracionException()
        {
        }

        public RepositorioConfiguracionException(string message)
            : base(message)
        {
        }

        public RepositorioConfiguracionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
