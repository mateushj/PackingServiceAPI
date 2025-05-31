namespace PackingServiceAPI.Models
{
    public class Dimensoes
    {
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Comprimento { get; set; }

        public int Volume => Altura * Largura * Comprimento;

        public bool CabeEm(Dimensoes caixa)
        {
            return Altura <= caixa.Altura && Largura <= caixa.Largura && Comprimento <= caixa.Comprimento;
        }
    }
}