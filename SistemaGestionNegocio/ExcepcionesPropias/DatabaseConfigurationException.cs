using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class DatabaseConfigurationException: Exception
    {
        public DatabaseConfigurationException()
        {
        }

        public DatabaseConfigurationException(string message): base(message)
        {
        }

        public DatabaseConfigurationException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}
