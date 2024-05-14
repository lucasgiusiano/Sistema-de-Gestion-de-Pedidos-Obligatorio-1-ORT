using SistemaGestionNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Usuario
{
    public class MapperUsuario
    {
        public static Usuario DTOAltaUsuarioToUsuario(DTOAltaUsuario nuevo)
        {
            Usuario usuario = new Usuario(nuevo.Email, nuevo.Nombre, nuevo.Apellido, nuevo.Admin);
            usuario.Id = nuevo.Id;
            usuario.SetContraseña(nuevo.Contrasenia);

            return usuario;
        }

        public static DTOAltaUsuario toDTOAltaUsuario(Usuario usu)
        {
            return new DTOAltaUsuario(usu.Id, usu.Email, usu.Nombre, usu.Apellido, usu.Contrasenia, usu.Admin);
        }

        public static DTOLoginUsuario toDTOLoginUsuario(Usuario usuario)
        {
            return new DTOLoginUsuario()
            {
                Id = usuario.Id,
                Email = usuario.Email,
                Contra = usuario.Contrasenia,
                AdminRol = usuario.Admin
            };
        }

        public static List<DTOAltaUsuario> toListaDTOAltaUsuario(List<Usuario> usuarios)
        {
            return usuarios.Select(usuario => toDTOAltaUsuario(usuario)).ToList();
        }
    }
}
