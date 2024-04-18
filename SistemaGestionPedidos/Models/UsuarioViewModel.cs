using System.ComponentModel.DataAnnotations;

namespace SistemaGestionPedidos.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "El campo Nombre solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio.")]
        [StringLength(50, ErrorMessage = "El campo Nombre no puede tener más de 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z\s'-]+$", ErrorMessage = "El campo Apellido solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio.")]
        [StringLength(50, ErrorMessage = "El campo Apellido no puede tener más de 50 caracteres.")]
        public string Apellido { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!])[A-Za-z\d.,;!]{6,}$", ErrorMessage = "La contraseña debe tener al menos 6 caracteres y contener al menos una letra mayúscula, una minúscula, un dígito y un carácter de puntuación.")]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        [Required(ErrorMessage = "Debe especificar el rol del nuevo usuario")]
        public bool Admin {  get; set; }

        public UsuarioViewModel(string email, string nombre, string apellido, string contrasenia, bool admin)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            Admin = admin;
        }

        public UsuarioViewModel()
        {

        }
    }
}
