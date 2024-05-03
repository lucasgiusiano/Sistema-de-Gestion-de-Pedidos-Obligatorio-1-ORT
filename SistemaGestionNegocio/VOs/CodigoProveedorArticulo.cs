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
    public class CodigoProveedorArticulo
    {
        public string Valor { get; init; }

        public CodigoProveedorArticulo(string valor)
        {
            Valor = valor;
            Validar();
        }
        private CodigoProveedorArticulo()
        {

        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Valor) || Valor.Length != 13)
            {
                throw new ArticuloValidationException("El código del proveedor debe tener 13 dígitos.");
            }
        }

        public override bool Equals(object? obj)
        {
            CodigoProveedorArticulo otro = obj as CodigoProveedorArticulo;

            if (otro == null) return false;

            return otro.Valor == this.Valor;
        }
    }
}
