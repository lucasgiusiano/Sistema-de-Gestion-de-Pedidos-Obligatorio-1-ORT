using SistemaGestionAplicacion.InterfacesCU.ICUCliente;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUCliente
{
    public class CUObtenerTodosLosClientesConDireccion : ICUObtenerTodosLosClientesConDireccion
    {
        private readonly IRepositorioCliente _repo;

        public CUObtenerTodosLosClientesConDireccion(IRepositorioCliente repo)
        {
            _repo = repo;
        }
        public List<Cliente> ObtenerTodosLosClientesConDireccion()
        {
            return _repo.ObtenerTodosLosClientesConDireccion();
        }
    }
}
