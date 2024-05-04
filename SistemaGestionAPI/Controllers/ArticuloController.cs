using DTOs.DTOs_Articulo;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.InterfacesCU.ICUArticulo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaGestionAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticuloController : ControllerBase
	{
		private readonly ICUListadoOrdenadoArticulos CUListado;

		public ArticuloController(ICUListadoOrdenadoArticulos cUListado)
		{
			CUListado = cUListado;
		}


		// GET: api/<ArticuloController>
		[HttpGet]
		public ActionResult<IEnumerable<DTOAltaArticulo>> GetListadoOrdenadoDeArticulos()
		{
			try
			{
				return Ok(CUListado.ListadoOrdenado());
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error al cargar los articulos: {ex.Message}");
			}
			
		}
	}
}
