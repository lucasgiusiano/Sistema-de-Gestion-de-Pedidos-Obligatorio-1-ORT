﻿
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionDatos.Repositorios
{
    public class RepositorioConfiguracion: IRepositorioConfiguracion
    {
        public SistemaGestionContext DBContext { get; set; }

        public RepositorioConfiguracion(SistemaGestionContext ctx)
        {
            DBContext = ctx;
        }
        public double ObtenerPlazoMaximoExpress()
        {
            try
            {
                var configuracion = DBContext.Configuraciones.FirstOrDefault(c => c.Nombre == "PlazoMaximoExpress");
                return configuracion?.Valor ?? 0;
            }
            catch (Exception ex)
            {

                throw new RepositorioConfiguracionException("Error al obtener el plazo máximo express.", ex);
            }
        }

        public double ObtenerIVA()
        {
            try
            {
                var configuracion = DBContext.Configuraciones.FirstOrDefault(c => c.Nombre == "IVA");
                return configuracion?.Valor ?? 0;
            }
            catch (Exception ex)
            {

                throw new RepositorioConfiguracionException("Error al obtener el valor del IVA.", ex);
            }
        }
        public double ObtenerRecargoPedidoExpressEnElDia()
        {
            try
            {
                var configuracion = DBContext.Configuraciones.FirstOrDefault(c => c.Nombre == "RecargoPedidoExpressEnElDia");
                return configuracion?.Valor ?? 0;
            }
            catch (Exception ex)
            {

                throw new RepositorioConfiguracionException("Error al obtener el valor del Recargo Pedido Express en el dia.", ex);
            }
        }
        public double ObtenerRecargoPedidoExpress()
        {
            try
            {
                var configuracion = DBContext.Configuraciones.FirstOrDefault(c => c.Nombre == "RecargoPedidoExpress");
                return configuracion?.Valor ?? 0;
            }
            catch (Exception ex)
            {

                throw new RepositorioConfiguracionException("Error al obtener el valor del Recargo Pedido Express.", ex);
            }
        }
        public double ObtenerRecargoPedidoComun()
        {
            try
            {
                var configuracion = DBContext.Configuraciones.FirstOrDefault(c => c.Nombre == "RecargoPedidoComun");
                return configuracion?.Valor ?? 0;
            }
            catch (Exception ex)
            {

                throw new RepositorioConfiguracionException("Error al obtener el valor del Recargo Pedido Comun.", ex);
            }
        }
    }
}
