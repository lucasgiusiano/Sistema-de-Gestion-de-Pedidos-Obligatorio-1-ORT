using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.DTOs_Configuracion;
using SistemaGestionNegocio.Dominio;

namespace DTOs.DTOs_Configuracion
{
    public class MapperConfiguracion
    {
        public static DTOConfiguracion MapToDTO(Configuracion configuracion)
        {
            return new DTOConfiguracion
            {
                Id = configuracion.Id,
                Nombre = configuracion.Nombre,
                Valor = configuracion.Valor
            };
        }

        public static Configuracion MapToEntity(DTOConfiguracion dtoConfiguracion)
        {
            return new Configuracion
            {
                Id = dtoConfiguracion.Id,
                Nombre = dtoConfiguracion.Nombre,
                Valor = dtoConfiguracion.Valor
            };
        }
    }
}
