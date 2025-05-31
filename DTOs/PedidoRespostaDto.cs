using System.Text.Json.Serialization;
namespace PackingServiceAPI.DTOs
{
    public class PedidoRespostaDto
    {
        [JsonPropertyName("pedido_id")]
        public int PedidoId { get; set; }

        [JsonPropertyName("caixas")]
        public List<CaixaRespostaDto> Caixas { get; set; }
    }
}
