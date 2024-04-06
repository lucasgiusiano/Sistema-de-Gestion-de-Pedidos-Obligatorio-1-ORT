using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.InterfacesRepositorio
{
    public interface IRepositorio<T>
    {
        void Alta(T nuevo);
        void Baja(Guid id);
        void Modificar(T modificado);
        List<T> ObtenerListado();
        T BuscarPorId(Guid id);
    }
}
