using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOs_Usuario
{
    public class DTOLoginUsuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Contra { get; set; }
        public bool AdminRol { get; set; }

        public DTOLoginUsuario(int id, string email, string contra, bool adminRol)
        {
            Id = id;
            Email = email;
            Contra = contra;
            AdminRol = adminRol;
        }

        public DTOLoginUsuario()
        {
            
        }
    }
}
