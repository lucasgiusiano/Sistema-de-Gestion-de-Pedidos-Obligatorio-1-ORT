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
        public ICUAlta<Usuario> CUAlta { get; set; }
        public ICUBaja CUBaja { get; set; }
        public ICUListado<Usuario> CUListado { get; set; }
        public ICUBuscar<Usuario> CUBuscar { get; set; }
        public ICUBuscarXEmail CUBuscarXEmail { get; set; }
        public ICUModificar<Usuario> CUModificar { get; set; }
        public ICUValidarLogin CUValidarLogin { get; set; }

        public UsuarioController(ICUAlta<Usuario> cuAlta, ICUBaja cuBaja, ICUListado<Usuario> cuListado, ICUBuscar<Usuario> cuBuscar, ICUBuscarXEmail cuBuscarXEmail, ICUModificar<Usuario> cuModificar, ICUValidarLogin cuValidarLogin)
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
            return View(CUListado.ObtenerListado());
        }

        // GET: UsuarioController
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
                Usuario aValidar = CUValidarLogin.ValidarLogin(email, password);

                HttpContext.Session.SetString("IdUsuarioLogueado", aValidar.Id.ToString());
                HttpContext.Session.SetString("EmailUsuarioLogueado", aValidar.Email);
                if (aValidar.Admin)
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
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel nuevo)
        {
            try
            {
                if (CUBuscarXEmail.BuscarXEmail(nuevo.Email) == null)
                {
                    Usuario nuevoU = new Usuario();
                    nuevoU.Nombre = nuevo.Nombre;
                    nuevoU.Apellido = nuevo.Apellido;
                    nuevoU.SetContraseña(nuevo.Contrasenia);
                    nuevoU.Email = nuevo.Email;
                    nuevoU.Admin = nuevo.Admin;

                    CUAlta.Alta(nuevoU);

                    return RedirectToAction("Index");
                }
                else
                {
                    throw new UsuarioValidationException("Ya existe un usuario con el email proporcionado");
                }
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
        public ActionResult Edit(Guid id)
        {
            try
            {
                Usuario Buscado = CUBuscar.Buscar(id);
                UsuarioViewModel model = new UsuarioViewModel();

                model.Id = Buscado.Id;
                model.Nombre = Buscado.Nombre;
                model.Apellido = Buscado.Apellido;
                model.Email = Buscado.Email;
                model.Contrasenia = Buscado.Contrasenia;
                model.Admin = Buscado.Admin;

				return View(model);
			}
            catch (Exception e)
            {
                ViewBag.Error = "Ocurrio un error inesperado";
            }
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(UsuarioViewModel usuarioEditado)
        {
            try
            {
				Usuario usuarioE = new Usuario();
                usuarioE.Id = usuarioEditado.Id;
				usuarioE.Nombre = usuarioEditado.Nombre;
				usuarioE.Apellido = usuarioEditado.Apellido;
				usuarioE.SetContraseña(usuarioEditado.Contrasenia);
				usuarioE.Email = usuarioEditado.Email;
				usuarioE.Admin = usuarioEditado.Admin;

                CUModificar.Modificar(usuarioE);

				return RedirectToAction(nameof(Index));
            }
            catch(UsuarioValidationException e)
            {
				ViewBag.Error = e.Message;
			}
            catch
            {
                ViewBag.Error = "Ocurrió un error inesperado";
            }
			return View();
		}

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
