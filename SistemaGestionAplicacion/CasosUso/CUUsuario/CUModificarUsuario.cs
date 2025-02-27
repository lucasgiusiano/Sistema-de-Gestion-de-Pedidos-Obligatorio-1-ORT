﻿using DTOs.DTOs_Usuario;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionAplicacion.CasosUso.CUUsuario
{
    public class CUModificarUsuario : ICUModificar<DTOAltaUsuario>
    {
        public IRepositorioUsuario Repo { get; set; }

        public CUModificarUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Modificar(DTOAltaUsuario modificado)
        {
            Usuario uModificado = MapperUsuario.DTOAltaUsuarioToUsuario(modificado);
            uModificado.Validar();
			Repo.Modificar(uModificado);
        }
    }
}
