using SistemaGestionNegocio.Dominio;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPedidos.Models
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Display(Name = "RUT")]
        public string Rut { get; set; }

        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Display(Name = "Numero")]
        public int Numero { get; set; }

        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Distancia desde el depósito")]
        public double DistanciaDeposito { get; set; }
        public Direccion Direccion { get; set; } = new Direccion();
    }
}
