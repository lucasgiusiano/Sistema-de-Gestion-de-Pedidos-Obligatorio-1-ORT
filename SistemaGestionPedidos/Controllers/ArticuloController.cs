using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.Dominio;
using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionPedidos.Models;

namespace SistemaGestionPedidos.Controllers
{
    public class ArticuloController : Controller
    {
        public ICUAlta<Articulo> CUAlta { get; set; }
        public ICUModificar<Articulo> CUModificar { get; set; }
        public ICUBuscar<Articulo> CUBuscar { get; set; }
        public ICUListadoOrdenadoArticulos CUListado { get; set; }

        public ArticuloController(ICUAlta<Articulo> cuAlta, ICUListadoOrdenadoArticulos cuListado, ICUModificar<Articulo> cUModificar, ICUBuscar<Articulo> cUBuscar)
        {
            CUAlta = cuAlta;
            CUListado = cuListado;
            CUModificar = cUModificar;
            CUBuscar = cUBuscar;
        }

        // GET: ArticuloController
        public ActionResult Index()
        {
            return View(CUListado.ListadoOrdenado());
        }

        // GET: ArticuloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticuloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticuloViewModel nuevoA)
        {
            try
            {
                CUAlta.Alta(convertirAArticulo(nuevoA));
                return RedirectToAction("Index");
            }
            catch (ArticuloValidationException e)
            {
                ViewBag.Error = e.Message;
            }
            catch (Exception)
            {
				ViewBag.Error = "Ocurrió un error inesperado";
			}
			return View();
		}

        // GET: ArticuloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(convertirAViewModel(CUBuscar.Buscar(id)));
        }

        // POST: ArticuloController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticuloViewModel model)
        {
            try
            {
                CUModificar.Modificar(convertirAArticulo(model));
                return RedirectToAction("Index");
            }
            catch (ArticuloValidationException e)
            {
                ViewBag.Error = e.Message;
            }
            catch (Exception)
            {
                ViewBag.Error = "Ocurrió un error inesperado";
            }
            return View();
        }

        private Articulo convertirAArticulo(ArticuloViewModel model)
        {
            return new Articulo(model.Nombre, model.Descripcion, model.CodigoProveedor, model.PrecioVenta, model.Stock);
        }

        private ArticuloViewModel convertirAViewModel(Articulo articulo)
        {
            return new ArticuloViewModel(articulo.Nombre,articulo.Descripcion,articulo.CodigoProveedor,articulo.PrecioVenta,articulo.Stock);
        }
    }
}
