using Microsoft.EntityFrameworkCore;
using SistemaGestionNegocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.VOs
{
    [Owned]
    public class DescripcionArticulo
    {
        public string Valor { get; init; }

        public DescripcionArticulo(string valor)
        {
            Valor = valor;
            Validar();
        }
        private DescripcionArticulo()
        {

        }

        private void Validar()
        {
            if (Valor.Length < 5)
            {
                throw new ArticuloValidationException("La descripción del artículo debe tener al menos 5 caracteres.");
            }
        }

        public override bool Equals(object? obj)
        {
            DescripcionArticulo otro = obj as DescripcionArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
