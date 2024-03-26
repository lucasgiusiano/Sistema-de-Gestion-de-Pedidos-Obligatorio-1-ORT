using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public Direccion Direccion { get; set; }

        public Cliente(string razonSocial, string rut, Direccion direccion)
        {
            Id = Guid.NewGuid(); // Inicializa Id cuando se crea una nueva instancia de Cliente
            RazonSocial = razonSocial;
            Rut = rut;
            Direccion = direccion;
        }
    }
}
