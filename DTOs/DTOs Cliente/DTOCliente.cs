using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Cliente
{
    public class DTOCliente
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }
        public double DistanciaDeposito { get; set; }

    }
}
