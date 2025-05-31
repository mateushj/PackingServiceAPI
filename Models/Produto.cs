using System.Text.Json.Serialization;

namespace PackingServiceAPI.Models
{
    public class Produto
    {
        [JsonPropertyName("produto_id")]
        public string ProdutoId { get; set; }
         public string? CaixaId { get; set; }
        public string Nome { get; set; } = string.Empty;

        [JsonPropertyName("dimensoes")]
        public Dimensoes Dimensoes { get; set; } = new();
    }
}