﻿using DTOs.DTOs_Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.InterfacesCU.ICUArticulo
{
    public interface ICUModificarArticulo
    {
        public void Modificar(DTOAltaArticulo modificado);
    }
}
