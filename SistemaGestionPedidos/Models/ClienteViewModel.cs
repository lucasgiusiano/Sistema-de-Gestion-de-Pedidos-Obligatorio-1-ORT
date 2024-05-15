using SistemaGestionNegocio.Dominio;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPedidos.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "La razón social del cliente es obligatorio.")]
        public string RazonSocial { get; set; }

        [Display(Name = "RUT")]
        [Required(ErrorMessage = "El RUT del cliente es obligatorio.")]
        [Range(100000000000, 999999999999, ErrorMessage = "El número debe tener 12 dígitos.")]
        public string Rut { get; set; }

        [Display(Name = "Calle")]
        [Required(ErrorMessage = "La calle del cliente es obligatorio.")]
        public string Calle { get; set; }

        [Display(Name = "Numero")]
        [Required(ErrorMessage = "El número de calle del cliente es obligatorio.")]
        public int Numero { get; set; }

        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "La ciudad del cliente es obligatorio.")]
        public string Ciudad { get; set; }

        [Display(Name = "Distancia desde el depósito")]
        [Required(ErrorMessage = "La distancia al depósito del cliente es obligatorio.")]
        public double DistanciaDeposito { get; set; }

        public Direccion Direccion { get; set; }

        public ClienteViewModel(int id, string razonSocial, string rut, string calle, int numero, string ciudad, double distanciaDeposito)
        {
            Id = id;
            RazonSocial = razonSocial;
            Rut = rut;
            DistanciaDeposito = distanciaDeposito;
            Direccion = new Direccion(calle, numero, ciudad);
        }

        public ClienteViewModel()
        {

        }
    }
}
