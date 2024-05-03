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
    public class PrecioVentaArticulo
    {
        public double Valor { get; init; }

        public PrecioVentaArticulo(double valor)
        {
            Valor = valor;
            Validar();
        }
        private PrecioVentaArticulo()
        {

        }

        private void Validar()
        {
            if (Valor < 0)
            {
                throw new ArticuloValidationException("El precio de venta no puede ser negativo.");
            }
        }

        public override bool Equals(object? obj)
        {
            PrecioVentaArticulo otro = obj as PrecioVentaArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
