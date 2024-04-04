using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class ArticuloValidationException:Exception
    {
        public ArticuloValidationException()
        {
        }

        public ArticuloValidationException(string message)
            : base(message)
        {
        }

        public ArticuloValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
