using DTOs.DTOs_Articulo;
using DTOs.DTOs_Pedido;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionAplicacion.InterfacesCU.ICUPedido;
using SistemaGestionNegocio.ExcepcionesPropias;

namespace SistemaGestionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly ICUAltaPedido _cUAltaPedido;
        private readonly ICUAnularPedido _anularPedido;
        private readonly ICUListarPedidos _cuListarPedidos;

        public PedidosController(ICUAltaPedido cUAltaPedido, ICUAnularPedido cUAnularPedido, ICUListarPedidos cuListarPedidos)
        {
            _cUAltaPedido = cUAltaPedido;
            _anularPedido = cUAnularPedido;
            _cuListarPedidos = cuListarPedidos;
        }

        [HttpPost("altaPedido")]
        public async Task<IActionResult> AltaPedido([FromBody] DTOAltaPedido dtoAltaPedido)
        {
            try
            {
                // Validar el DTOAltaPedido
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
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

        [HttpDelete("anularPedido/{id}")]
        public async Task<IActionResult> AnularPedido(int id)
        {
            try
            {
                // Llamar al caso de uso para anular el pedido
                _anularPedido.Anular(id);

                // Si todo sale bien, retornar un Ok con un mensaje de éxito
                return Ok("Pedido anulado correctamente.");
            }
            catch (PedidoNotFoundException)
            {
                // Si el pedido no se encuentra, retornar un código de estado 404 con un mensaje
                return NotFound($"No se encontró el pedido con ID {id}.");
            }
            catch (Exception ex)
            {
                // Si ocurre alguna excepción, retornar un código de estado 500 con el mensaje de error
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al anular el pedido: {ex.Message}");
            }
        }

        [HttpGet("listarPedidosAnuladorPorFechaDeEntregaDec")]
        public IActionResult ListarPedidosAnuladosPorFecha()
        {
            try
            {
                // Llamar al caso de uso para listar pedidos anulados por fecha
                var pedidosAnulados = _cuListarPedidos.ListarPedidosAnulados();

                // Si se encuentran pedidos anulados, retornar un Ok con la lista de pedidos
                return Ok(pedidosAnulados);
            }
            catch (Exception ex)
            {
                // Si ocurre alguna excepción, retornar un código de estado 500 con el mensaje de error
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al listar pedidos anulados por fecha: {ex.Message}");
            }
        }



    }
}
