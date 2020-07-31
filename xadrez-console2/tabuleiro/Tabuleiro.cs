
namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas { get; set; }

        /*public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            //A variável Peca é criado como matriz e recebe de parâmetro as linhas e colunas
            //do construtor.
            pecas = new Peca[linhas, colunas]; 
        }*/
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


    }
    
}
