using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace SistemaGestionNegocio.Dominio
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private string ContraseñaHasheada { get; set; }
        public bool Admin { get; set; }

        public Usuario(string email, string nombre, string apellido, string contraseña, bool admin)
        {
            Id = Guid.NewGuid();
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            ContraseñaHasheada = EncriptarContraseña(contraseña);
            Admin = admin;
        }

        private string EncriptarContraseña(string contraseña) // Genera un hash de la contraseña utilizando bcrypt (esta en el using)
        {

            return BCrypt.Net.BCrypt.HashPassword(contraseña);
        }

        public bool ValidarContraseña(string contraseña) // Validar la contraseña ingresada comparándola con el hash almacenado
        {

            return BCrypt.Net.BCrypt.Verify(contraseña, ContraseñaHasheada);
        }
    }
}
