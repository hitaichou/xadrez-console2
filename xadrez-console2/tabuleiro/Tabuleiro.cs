
namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] Peca { get; set; }

        public Tabuleiro(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
            //A variável Peca é criado como matriz e recebe de parâmetro as linhas e colunas
            //do construtor.
            Peca = new Peca[linha, coluna]; 
        }

    }
}
