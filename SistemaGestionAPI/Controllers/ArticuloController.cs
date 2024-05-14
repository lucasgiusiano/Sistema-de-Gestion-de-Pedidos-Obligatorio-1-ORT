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
		public ICUListadoOrdenadoArticulos CUListado { get; set; }

		public ArticuloController(ICUListadoOrdenadoArticulos cUListado)
		{
			CUListado = cUListado;
		}

		// GET: api/<ArticuloController>
		[HttpGet]
		public IActionResult Get()
		{
			try
			{
				return Ok(CUListado.ListadoOrdenado());
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Error : {ex.Message}");
			}
			
		}
	}
}
