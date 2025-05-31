using System.Text.Json.Serialization;

namespace PackingServiceAPI.DTOs
{
    public class CaixaRespostaDto
    {
        [JsonPropertyName("caixa_id")]
        public string CaixaId { get; set; }

        [JsonPropertyName("produtos")]
        public List<string> Produtos { get; set; }

        [JsonPropertyName("observacao")]
        public string Observacao { get; set; }
    }
}