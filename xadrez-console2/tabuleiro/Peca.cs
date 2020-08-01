
namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; } //somente pode ser acessada por ela e pela sua subclasse
        public int qteMovimentos { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.posicao = null; //qdo cria uma peça, ela ainda é nula.
            this.cor = cor;            
            this.tab = tab;
            this.qteMovimentos = 0;
        }
    }
}
