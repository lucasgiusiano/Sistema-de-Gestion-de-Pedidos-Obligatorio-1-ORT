using DTOs.DTOs_Pedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.CasosUso.CUPedido;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;

namespace SistemaGestionPedidos.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ICUAltaPedido _cUAltaPedido;
        private readonly ICUAnularPedido _anularPedido;
        private readonly ICUListarPedidosNoEntregadosPorFecha _cuListarPedidosNoEntregadosPorFecha;

        public PedidoController(ICUAltaPedido cUAltaPedido, ICUAnularPedido cUAnularPedido, ICUListarPedidosNoEntregadosPorFecha cuListarPedidosNoEntregadosPorFecha)
        {
            _cUAltaPedido = cUAltaPedido;
            _anularPedido = cUAnularPedido;
            _cuListarPedidosNoEntregadosPorFecha = cuListarPedidosNoEntregadosPorFecha;

        }

        public ActionResult Index()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                return View();
            }
        }

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


        // POST: Pedido/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DTOAltaPedido nuevoPedido)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var result = await _cUAltaPedido.Alta(nuevoPedido); 
                        if (result != null)
                        {
                            return RedirectToAction("DetallesPedido", "Pedido", result); 
                        }
                        else
                        {
                            ViewBag.Error = "El resultado de la creación del pedido es nulo.";
                            
                        }

                        return RedirectToAction("Create", "Pedido");
                    }
                    catch (PedidoValidationException e)
                    {
                        ViewBag.Error = e.Message;
                    }
                    catch (Exception)
                    {
                        ViewBag.Error = "Ocurrió un error inesperado";
                    }
                }
                return View();
            }
        }
        public ActionResult DetallesPedido(DTOPedido pedido)
        {
            if (pedido == null)
            {
                return RedirectToAction("Index", "Home");
            }
            TempData["SuccessMessage"] = "Pedido creado correctamente.";
            return View(pedido);
        }


        public ActionResult ListarPedidos()
        {
            if (String.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                return View(new List<DTOPedido>()); // Retorna una lista vacía al cargar la vista inicialmente.
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListarPedidos(DateTime FechaPedido)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                var pedidos = _cuListarPedidosNoEntregadosPorFecha.ListarPedidosNoEntregadosPorFecha(FechaPedido);
                return View("ListarPedidos", pedidos);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AnularPedido(int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("IdUsuarioLogueado")))
            {
                return RedirectToAction("Login", "Usuario");
            }
            else
            {
                try
                {
                    _anularPedido.Anular(id);
                    ViewBag.Message = "Pedido anulado correctamente.";
                }
                catch (Exception ex)
                {
                    ViewBag.Error = "Ocurrió un error al intentar anular el pedido: " + ex.Message;
                }
                // Recarga la lista de pedidos después de anular uno.
                return RedirectToAction("ListarPedidos");
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
    }
}
