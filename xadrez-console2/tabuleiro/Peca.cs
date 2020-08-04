
namespace tabuleiro
{
    abstract class Peca
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

        /*public void incrementarQteMovimento()
        {
            qteMovimentos++;
        }*/
        
        //é boleano, pois aqui é o momento no qual
        //a matriz vai dizer qual movimento é possível fazer
        //como no xadrez há diversas peças e seus movimentos são distintos, não é possível
        //determinar o movimento das peças dentro da classe Peca,
        //pois ela é muito genérica.
        //É preciso transformar o método em um método abstrado e a classe também.
        public abstract bool[,] movimentosPossiveis();
        

    }
}
