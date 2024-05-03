using SistemaGestionNegocio.VOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.Dominio
{
    public class Configuracion
    {
        public int Id { get; set; }
        public string Nombre { get; set;}
        public double Valor { get; set;}
    }
}
