using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionAplicacion.InterfacesCU.ICUUsuario;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;
using System.Reflection.Metadata;

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

        public UsuarioController(ICUAlta<Usuario> cuAlta,  ICUBaja cuBaja, ICUListado<Usuario> cuListado, ICUBuscar<Usuario> cuBuscar , ICUBuscarXEmail cuBuscarXEmail , ICUModificar<Usuario> cuModificar)
        {
            CUAlta = cuAlta;
            CUBaja = cuBaja;
            CUListado = cuListado;
            CUBuscar = cuBuscar;
            CUBuscarXEmail = cuBuscarXEmail;
            CUModificar = cuModificar;
        }

        // GET: UsuarioController
        public ActionResult Index()
        {
            return View();
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
            Usuario aValidar = new Usuario();
            try
            {
                aValidar = CUBuscarXEmail.BuscarXEmail(email);
                HttpContext.Session.SetString("EmailUsuarioLogueado", aValidar.Email) ;
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
        public ActionResult Create(IFormCollection collection)
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

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
