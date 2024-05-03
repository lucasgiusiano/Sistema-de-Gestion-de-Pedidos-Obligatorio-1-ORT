using DTOs.DTOs_Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionAplicacion.InterfacesCU.ICUUsuario;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionPedidos.Models;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace SistemaGestionPedidos.Controllers
{
    public class UsuarioController : Controller
    {
        public ICUAlta<DTOAltaUsuario> CUAlta { get; set; }
        public ICUBaja CUBaja { get; set; }
        public ICUListado<DTOAltaUsuario> CUListado { get; set; }
        public ICUBuscar<DTOAltaUsuario> CUBuscar { get; set; }
        public ICUBuscarXEmail CUBuscarXEmail { get; set; }
        public ICUModificar<DTOAltaUsuario> CUModificar { get; set; }
        public ICUValidarLogin CUValidarLogin { get; set; }

        public UsuarioController(ICUAlta<DTOAltaUsuario> cuAlta, ICUBaja cuBaja, ICUListado<DTOAltaUsuario> cuListado, ICUBuscar<DTOAltaUsuario> cuBuscar, ICUBuscarXEmail cuBuscarXEmail, ICUModificar<DTOAltaUsuario> cuModificar, ICUValidarLogin cuValidarLogin)
        {
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUListado = cuListado;
            CUBuscar = cuBuscar;
            CUBuscarXEmail = cuBuscarXEmail;
            CUModificar = cuModificar;
            CUValidarLogin = cuValidarLogin;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login");
            }
            else
            {
                return View(CUListado.ObtenerListado());
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            try
            {
                DTOLoginUsuario loginU = new DTOLoginUsuario()
                {
                    Email = email,
                    Contra = password
                };

                DTOLoginUsuario aValidar = CUValidarLogin.ValidarLogin(loginU);

                HttpContext.Session.SetString("IdUsuarioLogueado", aValidar.Id.ToString());
                HttpContext.Session.SetString("EmailUsuarioLogueado", aValidar.Email);
                if (aValidar.AdminRol)
                {
                    HttpContext.Session.SetString("RolUsuarioLogueado", "Admin");
                }
                else
                {
                    HttpContext.Session.SetString("RolUsuarioLogueado", "User");
                }
                return RedirectToAction("Index", "Home");

            }
            catch (UsuarioValidationException e)
            {
                ViewBag.Error = e.Message;
            }
            return View();
        }


        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            if (HttpContext.Session.GetString("RolUsuarioLogueado") == "Admin")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel nuevo)
        {
            try
            {
                CUAlta.Alta(convertirADTO(nuevo));

                return RedirectToAction("Index");
            }
            catch (UsuarioValidationException e)
            {
                ViewBag.Error = e.Message;
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocurrió un error inesperado";
            }
            return View();
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("RolUsuarioLogueado") == "Admin")
            {
                try
                {
                    return View(convertirAViewModel(CUBuscar.Buscar(id)));
                }
                catch (Exception e)
                {
                    ViewBag.Error = "Ocurrio un error inesperado";
                }
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuarioEditado)
        {
            try
            {
                CUModificar.Modificar(convertirADTO(usuarioEditado));

                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioValidationException e)
            {
                ViewBag.Error = e.Message;
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocurrió un error inesperado";
            }
            return View();
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("RolUsuarioLogueado") == "Admin")
            {
                return View(convertirAViewModel(CUBuscar.Buscar(id)));
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel model)
        {
            try
            {
                CUBaja.Baja(model.Id);
                return RedirectToAction(nameof(Index));
            }
            catch (UsuarioValidationException e)
            {
                ViewBag.Error = e.Message;
            }
            catch (Exception)
            {
                ViewBag.Error = "Ha ocurrido un error inesperado";
            }
            return View();
        }

        private UsuarioViewModel convertirAViewModel(DTOAltaUsuario usu)
        {
            UsuarioViewModel model = new UsuarioViewModel();
            model.Id = usu.Id;
            model.Nombre = usu.Nombre;
            model.Apellido = usu.Apellido;
            model.Email = usu.Email;
            model.Contrasenia = usu.Contrasenia;
            model.Admin = usu.Admin;

            return model;
        }

        private DTOAltaUsuario convertirADTO(UsuarioViewModel model)
        {
            DTOAltaUsuario usuario = new DTOAltaUsuario(model.Email, model.Nombre, model.Apellido, model.Contrasenia, model.Admin);

            return usuario;
        }
    }
}
