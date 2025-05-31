namespace PackingServiceAPI.Models
{
    public class Caixa
    {
        public string CaixaId { get; set; }
        public Dimensoes Dimensoes { get; set; } = new();
        public List<Produto> Produtos { get; set; } = new();
        public string? Observacao { get; set; }

        public int EspacoRestante => Dimensoes.Volume - Produtos.Sum(p => p.Dimensoes.Volume);

        public bool TentarAdicionarProduto(Produto produto)
        {
            if (!produto.Dimensoes.CabeEm(Dimensoes))
                return false;

            Produtos.Add(produto);
            produto.CaixaId = CaixaId;

            return true;
        }
    }
}