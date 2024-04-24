using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Usuario
{
    public class DTOAltaUsuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        public bool Admin { get; set; }

        public DTOAltaUsuario(int id, string email, string nombre, string apellido, string contrasenia, bool admin)
        {
            Id = id;
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            Admin = admin;
        }

        public DTOAltaUsuario(string email, string nombre, string apellido, string contrasenia, bool admin)
        {
            Email = email;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            Admin = admin;
        }

        public DTOAltaUsuario()
        {
            
        }
    }
}
