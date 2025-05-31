using Microsoft.AspNetCore.Mvc;
using PackingServiceAPI.DTOs;
using PackingServiceAPI.Models;
using PackingServiceAPI.Services;

namespace PackingServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmbalagemController : ControllerBase
    {
        private readonly EmbalagemService _embalagemService;

        public EmbalagemController(EmbalagemService embalagemService)
        {
            _embalagemService = embalagemService;
        }

        /// <summary>
        /// Processa uma lista de pedidos para definir quais caixas usar e quais produtos vão em cada caixa.
        /// </summary>
        /// <param name="pedidos">Lista de pedidos contendo produtos com dimensões.</param>
        /// <returns>Lista de pedidos com a distribuição dos produtos nas caixas.</returns>
        /// <response code="200">Pedidos empacotados com sucesso.</response>
        /// <response code="400">Lista de pedidos está vazia ou nula.</response>
        [HttpPost("empacotar")]
        [ProducesResponseType(typeof(List<PedidoRespostaDto>), 200)]
        [ProducesResponseType(400)]
        public ActionResult<List<PedidoRespostaDto>> EmpacotarPedidos([FromBody] PedidoLoteDto pedidoLote)
        {
            if (pedidoLote?.Pedidos == null || pedidoLote.Pedidos.Count == 0)
                return BadRequest("A lista de pedidos não pode ser vazia.");

            var resposta = _embalagemService.GerarRespostaEmpacotamento(pedidoLote.Pedidos);
            return Ok(resposta);
        }
    }
}
