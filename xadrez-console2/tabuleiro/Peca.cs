
namespace tabuleiro
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; } //somente pode ser acessada pela subclasse dela
        public int _qteMovimentos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor)
        {
            Posicao = posicao;
            Cor = cor;            
            Tabuleiro = tabuleiro;
            _qteMovimentos = 0;
        }
    }
}
