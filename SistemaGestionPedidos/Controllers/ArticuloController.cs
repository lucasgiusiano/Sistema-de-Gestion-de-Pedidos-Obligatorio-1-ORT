using DTOs.DTOs_Articulo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;
using SistemaGestionAplicacion.InterfacesCU.ICUGenericas;
using SistemaGestionNegocio.ExcepcionesPropias;
using SistemaGestionNegocio.VOs;
using SistemaGestionPedidos.Models;

namespace SistemaGestionPedidos.Controllers
{
    public class ArticuloController : Controller
    {
        public ICUAlta<DTOAltaArticulo> CUAlta { get; set; }
        public ICUModificar<DTOAltaArticulo> CUModificar { get; set; }
        public ICUBuscar<DTOAltaArticulo> CUBuscar { get; set; }
        public ICUListadoOrdenadoArticulos CUListado { get; set; }

        public ArticuloController(ICUAlta<DTOAltaArticulo> cuAlta, ICUListadoOrdenadoArticulos cuListado, ICUModificar<DTOAltaArticulo> cUModificar, ICUBuscar<DTOAltaArticulo> cUBuscar)
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
                CUAlta.Alta(convertirADTO(nuevoA));
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
                CUModificar.Modificar(convertirADTO(model));
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

        private DTOAltaArticulo convertirADTO(ArticuloViewModel model)
        {
            return new DTOAltaArticulo(model.Id, model.Nombre, model.Descripcion, model.CodigoProveedor, model.PrecioVenta,  model.Stock);
        }

        private ArticuloViewModel convertirAViewModel(DTOAltaArticulo dto)
        {
            return new ArticuloViewModel(dto.Nombre, dto.Descripcion, dto.CodigoProveedor, dto.PrecioVenta, dto.Stock);
        }
    }
}
