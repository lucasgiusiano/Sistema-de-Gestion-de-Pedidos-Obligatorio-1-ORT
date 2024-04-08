using Microsoft.EntityFrameworkCore.Infrastructure;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        public SistemaGestionContext DBContext { get; set; }

        public RepositorioUsuario(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }

        public void Alta(Usuario nuevo)
        {
            if (nuevo != null)
            {
                nuevo.Validar();
                DBContext.Usuarios.Add(nuevo);
                DBContext.SaveChanges();
            }
        }

        public void Baja(Guid id)
        {
            Usuario aEliminar = DBContext.Usuarios.Find(id);
            if (aEliminar != null)
            {
                DBContext.Usuarios.Remove(aEliminar);
                DBContext.SaveChanges();
            }

        }

        public Usuario BuscarPorId(Guid id)
        {
            return DBContext.Usuarios.Where(u => u.Id == id).SingleOrDefault();
        }

        public void Modificar(Usuario modificado)
        {
            if (modificado != null)
            {
                modificado.Validar();
                DBContext.Usuarios.Update(modificado);
                DBContext.SaveChanges();
            }
        }

        public List<Usuario> ObtenerListado()
        {
            return DBContext.Usuarios.ToList();
        }

        public Usuario BuscarXEmail(string email)
        {
            return DBContext.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public Usuario ValidarLogin(string email, string contrasenia)
        {
            Usuario buscado = BuscarXEmail(email);
            if (buscado != null && email == buscado.Email && Hashear(contrasenia) == buscado.ContraseniaHasheada)
            {
                return buscado;
            }
            else
            {
                throw new UsuarioValidationException("Credenciales Inválidas");
            }

        }

        private string Hashear(string contrasenia)
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
    }
}
