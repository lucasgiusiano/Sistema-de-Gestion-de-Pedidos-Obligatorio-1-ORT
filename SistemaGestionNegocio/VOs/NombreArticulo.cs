using Microsoft.EntityFrameworkCore;
using SistemaGestionNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistemaGestionNegocio.VOs
{
    [Owned]
    public class NombreArticulo
    {
        public string Valor { get; init; }

        public NombreArticulo(string valor)
        {
            Valor = valor;
            Validar();
        }
        private NombreArticulo()
        {

        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Valor))
            {
                throw new ArticuloValidationException("El nombre del artículo no puede estar vacío.");
            }
        }

        public override bool Equals(object? obj)
        {
            NombreArticulo otro = obj as NombreArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
