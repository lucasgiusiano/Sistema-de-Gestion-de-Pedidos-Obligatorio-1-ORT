using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.InterfacesRepositorio
{
    public interface IRepositorioConfiguracion
    {
        public double ObtenerPlazoMaximoExpress();
        public double ObtenerIVA();
        public double ObtenerRecargoPedidoExpressEnElDia();
        public double ObtenerRecargoPedidoExpress();
        public double ObtenerRecargoPedidoComun();
    }
}
