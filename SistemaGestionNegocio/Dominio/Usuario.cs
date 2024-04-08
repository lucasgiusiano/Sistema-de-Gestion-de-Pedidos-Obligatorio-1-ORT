using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BCrypt.Net;
using SistemaGestionNegocio.InterfacesDominio;
using System.Security.Cryptography;
using SistemaGestionNegocio.ExcepcionesPropias;

namespace SistemaGestionNegocio.Dominio
{
    public class Usuario: IValidable
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "El campo Email debe ser una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [RegularExpression(@"^[a-zA-Z' -]+$", ErrorMessage = "El campo Nombre solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio.")]
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [RegularExpression(@"^[a-zA-Z' -]+$", ErrorMessage = "El campo Apellido solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio.")]
        [Required(ErrorMessage = "El campo Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Display(Name = "Contraseña Hasheada")]
        public string ContraseniaHasheada { get; set; }

        [Required(ErrorMessage = "El campo Contraseña es obligatorio.")]
        [Display(Name = "Contraseña")]
        public string Contrasenia { get; set; }
        public bool Admin { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid(); 
        }

        public void SetContraseña(string contrasenia)
        {
            
            if (!ValidarContraseña(contrasenia))
            {
                throw new ArgumentException("La contraseña no cumple con los requisitos mínimos.");
            }

            ContraseniaHasheada = EncriptarContrasenia(contrasenia);// Encripta la contraseña y almacenarla
            Contrasenia = contrasenia;
        }

        public bool ValidarContraseña(string contrasenia)
        {
            if (string.IsNullOrEmpty(contrasenia) || contrasenia.Length < 6)
            {
                return false;
            }

            if (!Regex.IsMatch(contrasenia, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.,;!]$)"))
            {
                return false;
            }

            return true;
        }

        private string EncriptarContrasenia(string contrasenia)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Generar un hash de la contraseña
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));

                // Convertir bytes a string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void Validar()
        {
            var error = new List<string>();

            // Valida el campo Email
            if (string.IsNullOrWhiteSpace(Email))
            {
                error.Add("El campo Email es obligatorio.");
            }
            else if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                error.Add("El campo Email debe ser una dirección de correo electrónico válida.");
            }

            // Valida el campo Nombre
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                error.Add("El campo Nombre es obligatorio.");
            }
            else if (!Regex.IsMatch(Nombre, @"^[a-zA-Z' -]+$"))
            {
                error.Add("El campo Nombre solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio, y no puede empezar ni terminar con caracteres no alfabéticos.");
            }

            // Validar el campo Apellido
            if (string.IsNullOrWhiteSpace(Apellido))
            {
                error.Add("El campo Apellido es obligatorio.");
            }
            else if (!Regex.IsMatch(Apellido, @"^[a-zA-Z' -]+$"))
            {
                error.Add("El campo Apellido solo puede contener caracteres alfabéticos, espacio, apóstrofe o guión del medio, y no puede empezar ni terminar con caracteres no alfabéticos.");
            }

            if (error.Any())
            {
                // Si hay errores de validación, lanzar una excepción con los mensajes de error
                throw new UsuarioValidationException(string.Join(Environment.NewLine, error));
            }
        }

    }
}
