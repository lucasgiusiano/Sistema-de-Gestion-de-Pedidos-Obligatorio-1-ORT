using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Cliente: IValidable
    {
        public Guid Id { get; set; }
        public string RazonSocial { get; set; }
        public string Rut { get; set; }
        public Direccion Direccion { get; set; }
        public double DistanciaDeposito { get; set; }

        public Cliente()
        {
            Id = Guid.NewGuid(); 
        }

        public void Validar()
        {
        
            if (string.IsNullOrWhiteSpace(RazonSocial))
            {
                throw new ClienteValidationException("La razón social del cliente no puede estar vacía.");
            }

            
            if (string.IsNullOrWhiteSpace(Rut) || Rut.Length != 12)
            {
                throw new ClienteValidationException("El RUT del cliente debe tener 12 caracteres.");
            }

            
            if (Direccion == null || string.IsNullOrWhiteSpace(Direccion.Calle) || string.IsNullOrWhiteSpace(Direccion.Ciudad))
            {
                throw new ClienteValidationException("La dirección del cliente debe incluir la calle y la ciudad.");
            }

            
            if (DistanciaDeposito < 0)
            {
                throw new ClienteValidationException("La distancia desde el depósito de la papelería no puede ser negativa.");
            }
        }
    }
}
