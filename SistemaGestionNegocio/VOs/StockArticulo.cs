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
    public class StockArticulo
    {
        public int Valor { get; init; }

        public StockArticulo(int valor)
        {
            Valor = valor;
            Validar();
        }
        private StockArticulo()
        {

        }

        private void Validar()
        {
            if (Valor < 0)
            {
                throw new ArticuloValidationException("El stock no puede ser negativo.");
            }
        }

        public override bool Equals(object? obj)
        {
            StockArticulo otro = obj as StockArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
