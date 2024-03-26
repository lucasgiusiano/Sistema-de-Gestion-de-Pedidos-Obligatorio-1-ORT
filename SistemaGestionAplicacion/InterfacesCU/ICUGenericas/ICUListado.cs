using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUGenericas
{
    public interface ICUListado<T>
    {
        List<T> ObtenerListado();
    }
}
