
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas { get; set; }

        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            //A variável Peca é criado como matriz e recebe de parâmetro as linhas e colunas
            //do construtor.
            pecas = new Peca[linhas, colunas];
        }

        //Como o atributo Peca é privativo, crio um método
        //no qual insere no atributo o valor de linha e coluna.
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        //Vou na matriz (acesso a matriz) de peças na posição.
        //recebo a peça p e adiciono na matriz na posição pos.linha, pos.coluna
        public void colocarPeca(Peca p, Posicao pos)
        {
            pecas[pos.Linha, pos.Coluna] = p;
            p.posicao = pos; //vou na peça p e digo que a posição dela agora é pos
        }


    }
    
}
