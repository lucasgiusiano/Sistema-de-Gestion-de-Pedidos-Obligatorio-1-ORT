using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;

namespace SistemaGestionPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ICUAltaPedido _cUAltaPedido;
        private readonly ICUAnularPedido _anularPedido;
        private readonly ICUListarPedidos _cuListarPedidos;

        public PedidoController(ICUAltaPedido cUAltaPedido, ICUAnularPedido cUAnularPedido, ICUListarPedidos cuListarPedidos)
        {
            _cUAltaPedido = cUAltaPedido;
            _anularPedido = cUAnularPedido;
            _cuListarPedidos = cuListarPedidos;
        }



        // GET: PedidoController
        public ActionResult Index()
        {
                return View("~/Views/Pedido/ListarPedidos.cshtml");
            
        }

        // GET: PedidoController/Details/5
        public ActionResult Details(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // GET: PedidoController/Create
        public ActionResult Create()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: PedidoController/Create
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

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: PedidoController/Edit/5
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

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View();
            }
        }

        // POST: PedidoController/Delete/5
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
