﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionNegocio.ExcepcionesPropias
{
    public class StockInsuficienteException: Exception
    {
        public StockInsuficienteException()
        {
        }

        public StockInsuficienteException(string message)
            : base(message)
        {
        }

        public StockInsuficienteException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
