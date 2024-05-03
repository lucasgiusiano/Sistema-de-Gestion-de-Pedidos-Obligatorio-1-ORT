using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Direccion
    {
        public int Id { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public string Ciudad { get; set; }

        public Direccion(string calle, int numero, string ciudad)
        {
            Calle = calle;
            Numero = numero;
            Ciudad = ciudad;
        }

        public Direccion()
        {
            
        }
    }
}
