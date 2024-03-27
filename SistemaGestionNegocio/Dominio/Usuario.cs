using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
using SistemaGestionNegocio.InterfacesDominio;

namespace SistemaGestionNegocio.Dominio
{
    public class Usuario: IValidable
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private string ContraseniaHasheada { get; set; }
        private string Contrasenia { get; set; }
        public bool Admin { get; set; }

        public Usuario(string email, string nombre, string apellido, string contrasenia, bool admin)
        {
            Id = Guid.NewGuid();
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            ContraseniaHasheada = EncriptarContraseña(contrasenia);
            Contrasenia = contrasenia;
            Admin = admin;
        }

        private string EncriptarContraseña(string contrasenia) // Genera un hash de la contraseña utilizando bcrypt (esta en el using)
        {
            return BCrypt.Net.BCrypt.HashPassword(contrasenia);
        }

        public bool ValidarContraseña(string contrasenia) // Validar la contraseña ingresada comparándola con el hash almacenado
        {
            return BCrypt.Net.BCrypt.Verify(contrasenia, ContraseniaHasheada);
        }

        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}
