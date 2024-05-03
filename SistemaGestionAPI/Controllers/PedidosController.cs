using DTOs.DTOs_Articulo;
using DTOs.DTOs_Pedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly ICUAltaPedido _cUAltaPedido;
        private readonly ICUAnularPedido _anularPedido;
        private readonly ICUListadoPedidosAnuladosXFecha _cUListadoPedidosAnuladosXFecha;

        public PedidosController(ICUAltaPedido cUAltaPedido, ICUAnularPedido cUAnularPedido, ICUListadoPedidosAnuladosXFecha cUListadoPedidosAnuladosXFecha)
        {
            _cUAltaPedido = cUAltaPedido;
            _anularPedido = cUAnularPedido;
            _cUListadoPedidosAnuladosXFecha = cUListadoPedidosAnuladosXFecha;
        }

        [HttpPost("altaPedido")]
        public async Task<IActionResult> AltaPedido([FromBody] DTOAltaPedido dtoAltaPedido)
        {
            try
            {
                // Validar el DTOAltaPedido
                if (dtoAltaPedido == null)
                {
                    return BadRequest("El DTOAltaPedido no puede ser nulo.");
                }

                // Llamar al caso de uso para dar de alta el pedido
                await _cUAltaPedido.Alta(dtoAltaPedido);

                // Si todo sale bien, retornar un Ok con un mensaje de éxito
                return Ok("Pedido creado correctamente.");
            }
            catch (Exception ex)
            {
                // Si ocurre alguna excepción, retornar un código de estado 500 con el mensaje de error
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al crear el pedido: {ex.Message}");
            }
        }


    }
}
