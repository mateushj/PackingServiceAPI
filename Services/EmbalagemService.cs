using PackingServiceAPI.Models;
using PackingServiceAPI.DTOs;

namespace PackingServiceAPI.Services
{
    public class EmbalagemService
    {
        private readonly List<Caixa> _modelosCaixas = new()
        {
            new Caixa { CaixaId = "Caixa 1", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
            new Caixa { CaixaId = "Caixa 2", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
            new Caixa { CaixaId = "Caixa 3", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } },
        };

        public List<PedidoRespostaDto> GerarRespostaEmpacotamento(List<Pedido> pedidos)
        {
            var resposta = new List<PedidoRespostaDto>();

            foreach (var pedido in pedidos)
            {
                var caixasUsadas = EmpacotarProdutos(pedido.Produtos);

                var caixasDto = caixasUsadas.Select(c => new CaixaRespostaDto
                {
                    CaixaId = c.CaixaId,
                    Produtos = c.Produtos.Select(p => p.ProdutoId).ToList(),
                    Observacao = c.Observacao
                }).ToList();

                resposta.Add(new PedidoRespostaDto
                {
                    PedidoId = pedido.PedidoId,
                    Caixas = caixasDto
                });
            }

            return resposta;
        }

        public List<Caixa> EmpacotarProdutos(List<Produto> produtos)
        {
            var caixasResultado = new List<Caixa>();

            foreach (var produto in produtos)
            {
                var caixaEncontrada = caixasResultado.FirstOrDefault(c => c.TentarAdicionarProduto(produto));

                if (caixaEncontrada != null)
                    continue;

                // Tentar nova caixa
                var novaCaixa = _modelosCaixas
                    .Select(c => new Caixa { CaixaId = c.CaixaId, Dimensoes = c.Dimensoes })
                    .FirstOrDefault(c => produto.Dimensoes.CabeEm(c.Dimensoes));

                if (novaCaixa != null)
                {
                    novaCaixa.Produtos.Add(produto);
                    caixasResultado.Add(novaCaixa);
                }
                else
                {
                    caixasResultado.Add(new Caixa
                    {
                        CaixaId =string.Empty,
                        Produtos = new List<Produto> { produto },
                        Observacao = "Produto não cabe em nenhuma caixa disponível."
                    });
                }
            }

            return caixasResultado;
        }
    }
}